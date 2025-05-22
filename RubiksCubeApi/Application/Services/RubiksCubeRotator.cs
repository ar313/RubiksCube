using RubiksCubeApi.Domain.Entities;
using RubiksCubeApi.Models.Enums;

namespace RubiksCubeApi.Application.Services
{
    public class RubiksCubeRotator : IRubiksCubeRotator
    {
        public void Rotate(RubiksCube cube, FaceRubik face, RotationRubik rotation)
        {
            var grid = cube.GetFaceGrid(face);
            var rotatedGrid = RotateFaceMatrix(grid, rotation);
            cube.SetFaceGrid(face, rotatedGrid);

            switch (face)
            {
                case FaceRubik.Front:
                    RotateEdges(
                        cube,
                        new[] {
                        (FaceRubik.Up,    2, true, false),
                        (FaceRubik.Right, 0, false, false),
                        (FaceRubik.Down,  0, true, true),
                        (FaceRubik.Left,  2, false, true)
                        }, rotation);
                    break;

                case FaceRubik.Back:
                    RotateEdges(cube,
                        new[] {
                        (FaceRubik.Up,    0, true, true),
                        (FaceRubik.Left,  0, false, false),
                        (FaceRubik.Down,  2, true, false),
                        (FaceRubik.Right, 2, false, true)
                        }, rotation);
                    break;

                case FaceRubik.Up:
                    RotateEdges(cube,
                        new[] {
                        (FaceRubik.Back,  0, true, false),
                        (FaceRubik.Right, 0, true, false),
                        (FaceRubik.Front, 0, true, false),
                        (FaceRubik.Left,  0, true, false)
                        }, rotation);
                    break;

                case FaceRubik.Down:
                    RotateEdges(cube,
                        new[] {
                        (FaceRubik.Front, 2, true, false),
                        (FaceRubik.Right, 2, true, false),
                        (FaceRubik.Back,  2, true, false),
                        (FaceRubik.Left,  2, true, false)
                        }, rotation);
                    break;

                case FaceRubik.Left:
                    RotateEdges(cube,
                        new[] {
                        (FaceRubik.Up,    0, false, false),
                        (FaceRubik.Front, 0, false, false),
                        (FaceRubik.Down,  0, false, false),
                        (FaceRubik.Back,  2, false, true)
                        }, rotation);
                    break;

                case FaceRubik.Right:
                    RotateEdges(cube,
                        new[] {
                        (FaceRubik.Up,    2, false, false),
                        (FaceRubik.Back,  0, false, true),
                        (FaceRubik.Down,  2, false, false),
                        (FaceRubik.Front, 2, false, false)
                        }, rotation);
                    break;
            }
        }

        //Rotate the face around its center
        private ColorRubik[][] RotateFaceMatrix(ColorRubik[][] grid, RotationRubik rotation)
        {
            ColorRubik[][] result = new ColorRubik[3][] { new ColorRubik[3], new ColorRubik[3], new ColorRubik[3] };

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (rotation == RotationRubik.Clockwise)
                    {
                        result[row][col] = grid[2 - col][row]; // column to row 

                    }
                    else
                    {
                        result[row][col] = grid[col][2 - row]; // row to column
                    }
                }
            }

            return result;
        }

        //Rotate neighbouring face edges
        private void RotateEdges(RubiksCube cube,
            (FaceRubik face, int index, bool isRow, bool reverse)[] edges,
            RotationRubik rotation)
        {
            ColorRubik[][] temp = new ColorRubik[4][];
            for (int edgeIndex = 0; edgeIndex < 4; edgeIndex++) // Get each touching edge column or row
            {
                var (face, indexRow, isRow, reversed) = edges[edgeIndex];
                temp[edgeIndex] = new ColorRubik[3];
                var faceGrid = cube.GetFaceGrid(face);

                for (int col = 0; col < 3; col++)
                {
                    int indexCol = col;

                    if (reversed)
                    {
                        indexCol = 2 - col;
                    }

                    if (isRow)
                    {
                        temp[edgeIndex][col] = faceGrid[indexRow][indexCol]; // Save Row 
                    }
                    else
                    {
                        temp[edgeIndex][col] = faceGrid[indexCol][indexRow]; // Save Column
                    }
                }
            }

            for (int edgeIndex = 0; edgeIndex < 4; edgeIndex++)
            {
                int from = (edgeIndex + 1) % 4;

                if (rotation == RotationRubik.Clockwise)
                {
                    from = (edgeIndex + 3) % 4;
                }

                var (face, indexRow, isRow, reversed) = edges[edgeIndex];
                var faceGrid = cube.GetFaceGrid(face);

                for (int col = 0; col < 3; col++)
                {
                    int indexCol = reversed ? 2 - col : col;

                    if (isRow)
                    {

                        faceGrid[indexRow][indexCol] = temp[from][col];
                    }
                    else
                    {
                        faceGrid[indexCol][indexRow] = temp[from][col];
                    }
                }

                cube.SetFaceGrid(face, faceGrid);
            }
        }
    }
}

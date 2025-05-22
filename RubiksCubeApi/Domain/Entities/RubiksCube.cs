using RubiksCubeApi.Models.Enums;
using System.ComponentModel;

namespace RubiksCubeApi.Domain.Entities
{
    public class RubiksCube
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public List<RubiksBox> RubiksBoxes { get; set; } = new();

        public RubiksCube()
        {
            
        }

        public ColorRubik[][] GetFaceGrid(FaceRubik face)
        {
            var grid = new ColorRubik[3][]
            {
            new ColorRubik[3],
            new ColorRubik[3],
            new ColorRubik[3]
            };

            var faceStickers = RubiksBoxes.Where(s => s.Face == face);
            foreach (var s in faceStickers)
                grid[s.Row][s.Column] = s.Color;

            return grid;
        }

        public void SetFaceGrid(FaceRubik face, ColorRubik[][] grid)
        {
            var faceStickers = RubiksBoxes.Where(s => s.Face == face);
            foreach (var s in faceStickers)
                s.Color = grid[s.Row][s.Column];
        }

        public string StringCube()
        {
            string result = string.Empty;
            for (int face = 0; face < 6; face++)
            {
                FaceRubik faceToGet = (FaceRubik)face;
                result += $"{(FaceRubik)face} Face:";
                var cubeFace = GetFaceGrid(faceToGet);
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                        result += (cubeFace[row][col].ToString()[0] + " ");
                    result += '\n';
                }
                result += '\n';
            }
            return result;
        }

        public string StringCubeExploded()
        {
            string result = string.Empty;
            result += ("\n      [UP]");

            var cubeFaceUp = GetFaceGrid(FaceRubik.Up);
            var cubeFaceDown = GetFaceGrid(FaceRubik.Down);
            for (int row = 0; row < 3; row++)
            {
                result += ("\n       ");
                for (int col = 0; col < 3; col++)
                    result += ($"{ColorChar(cubeFaceUp[row][col])} ");
            }

            result += ("\n[LEFT][FRONT][RIGHT][BACK]\n");
            for (int row = 0; row < 3; row++)
            {
                for (int face = (int)FaceRubik.Left; face <= (int)FaceRubik.Back; face++)
                {
                    FaceRubik faceToGet = (FaceRubik)face;
                    var cubeFace = GetFaceGrid(faceToGet);
                    for (int col = 0; col < 3; col++)
                        result += ($"{ColorChar(cubeFace[row][col])} ");
                    result += (" ");
                }
                result += '\n';
            }

            result += ("      [DOWN]");
            for (int row = 0; row < 3; row++)
            {
                result += ("\n       ");
                for (int col = 0; col < 3; col++)
                    result += ($"{ColorChar(cubeFaceDown[row][col])} ");
            }

            return result;
        }

        private char ColorChar(ColorRubik color)
        {
            switch (color)
            {
                case ColorRubik.White: return  'W';
                case ColorRubik.Yellow: return 'Y';
                case ColorRubik.Orange: return 'O';
                case ColorRubik.Green: return  'G';
                case ColorRubik.Red: return    'R';
                case ColorRubik.Blue: return   'B';
                default: throw new InvalidEnumArgumentException("Color Does Not Exist");
            }
        }
    }
}

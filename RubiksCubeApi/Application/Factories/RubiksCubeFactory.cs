using RubiksCubeApi.Domain.Entities;
using RubiksCubeApi.Models.Enums;

namespace RubiksCubeApi.Application.Factories
{
    public class RubiksCubeFactory : IRubiksCubeFactory
    {
        public RubiksCube Create()
        {
            RubiksCube rubiksCube = new RubiksCube();

            for (int face = 0; face < 6; face++)
            {
                FaceRubik faceEnum = (FaceRubik)face;
                ColorRubik colorEnum = (ColorRubik)face;

                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        rubiksCube.RubiksBoxes.Add(new RubiksBox()
                        {
                            Face = faceEnum,
                            Row = row,
                            Column = col,
                            Color = colorEnum
                        });
                    }
                }
            }

            return rubiksCube;
        }


    }
}

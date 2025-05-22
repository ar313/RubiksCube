using RubiksCubeApi.Models.Enums;

namespace RubiksCubeApi.Infrastructure.Dto.Rubikscube
{
    public class RotateCubeDto
    {
        public FaceRubik FaceRubikToRotate { get; set; }
        public RotationRubik RubiksRotation { get; set; }
    }
}

using RubiksCubeApi.Models.Enums;
using RubiksCubeApi.Domain.Entities;

namespace RubiksCubeApi.Application.Services
{
    public interface IRubiksCubeRotator
    {
        public void Rotate(RubiksCube cube, FaceRubik face, RotationRubik rotation);
    }
}

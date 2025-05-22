using RubiksCubeApi.Application.Common;
using RubiksCubeApi.Domain.Entities;
using RubiksCubeApi.Infrastructure.Dto.Rubikscube;
using System.ComponentModel.DataAnnotations;

namespace RubiksCubeApi.Application.Commands
{
    public class RotateRubiksCubeCommand : BaseCommand<RubiksCubeDto>
    {
        public Guid Id { get; set; }
        public RotateCubeDto RotateCubeDto { get; set; }
    }
}

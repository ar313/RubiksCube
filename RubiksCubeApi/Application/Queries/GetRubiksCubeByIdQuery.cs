using RubiksCubeApi.Application.Interfaces;
using RubiksCubeApi.Infrastructure.Dto.Rubikscube;

namespace RubiksCubeApi.Application.Queries
{
    public class GetRubiksCubeByIdQuery : IBaseQuery<RubiksCubeDto>
    {
        public Guid CubeId { get; set; }
    }
}

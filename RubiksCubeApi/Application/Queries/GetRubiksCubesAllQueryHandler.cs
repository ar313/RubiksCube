using RubiksCubeApi.Application.Commands;
using RubiksCubeApi.Application.Common;
using RubiksCubeApi.Application.Interfaces;
using RubiksCubeApi.Application.Services;
using RubiksCubeApi.Infrastructure.Dto.Rubikscube;

namespace RubiksCubeApi.Application.Queries
{
    public class GetRubiksCubesAllQueryHandler : BaseQueryHandler<GetRubiksCubesAllQuery, List<RubiksCubeDto>>
    {
        private readonly ILogger<GetRubiksCubesAllQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetRubiksCubesAllQueryHandler(
            ILogger<GetRubiksCubesAllQueryHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(ILogger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));
        }

        protected override async Task<List<RubiksCubeDto>> HandleQueryAsync(GetRubiksCubesAllQuery query, CancellationToken cancellationToken)
        {
            var cubes = await _unitOfWork.RubiksCubeRepository.GetAllAsync(cancellationToken);

            var dtoCubes = cubes.Select(cube => new RubiksCubeDto(cube)).ToList();

            return dtoCubes;
        }
    }
}

using RubiksCubeApi.Application.Commands;
using RubiksCubeApi.Application.Common;
using RubiksCubeApi.Application.Interfaces;
using RubiksCubeApi.Application.Services;
using RubiksCubeApi.Infrastructure.Dto.Rubikscube;

namespace RubiksCubeApi.Application.Queries
{
    public class GetRubiksCubeByIdQueryHandler : BaseQueryHandler<GetRubiksCubeByIdQuery, RubiksCubeDto>
    {
        private readonly ILogger<GetRubiksCubeByIdQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetRubiksCubeByIdQueryHandler(
            ILogger<GetRubiksCubeByIdQueryHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(ILogger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));
        }

        protected override async Task<RubiksCubeDto> HandleQueryAsync(GetRubiksCubeByIdQuery query, CancellationToken cancellationToken)
        {
            var cube = await _unitOfWork.RubiksCubeRepository.GetByIdAsync(query.CubeId, cancellationToken);

            if (cube == null)
            {
                throw new ArgumentNullException($"Cube with ID {query.CubeId} not found.");
            }

            return new RubiksCubeDto(cube);
        }
    }
}

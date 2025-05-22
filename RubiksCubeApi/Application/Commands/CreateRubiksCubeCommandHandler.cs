using RubiksCubeApi.Application.Common;
using RubiksCubeApi.Application.Factories;
using RubiksCubeApi.Application.Interfaces;
using RubiksCubeApi.Domain.Entities;
using RubiksCubeApi.Infrastructure.Dto.Rubikscube;
using RubiksCubeApi.Infrastructure.UnitOfWork;

namespace RubiksCubeApi.Application.Commands
{
    public class CreateRubiksCubeCommandHandler : BaseCommandHandler<CreateRubiksCubeCommand, RubiksCubeDto>
    {
        private readonly IRubiksCubeFactory _factory;
        private readonly ILogger<CreateRubiksCubeCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRubiksCubeCommandHandler(
            IRubiksCubeFactory factory,
            ILogger<CreateRubiksCubeCommandHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(IRubiksCubeFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(ILogger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));
        }

        public override async Task<RubiksCubeDto> Handle(CreateRubiksCubeCommand request, CancellationToken cancellationToken)
        {
            var rubiksCube = _factory.Create();


            var rubiksCubeDto = new RubiksCubeDto(rubiksCube);

            _logger.LogInformation(rubiksCube.StringCubeExploded());

            _unitOfWork.RubiksCubeRepository.Create(rubiksCube);
            await _unitOfWork.CommitAsync();

            return rubiksCubeDto;
        }
    }
}

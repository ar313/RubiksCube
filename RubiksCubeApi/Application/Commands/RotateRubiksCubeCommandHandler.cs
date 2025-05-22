using RubiksCubeApi.Application.Common;
using RubiksCubeApi.Application.Factories;
using RubiksCubeApi.Application.Interfaces;
using RubiksCubeApi.Application.Services;
using RubiksCubeApi.Domain.Entities;
using RubiksCubeApi.Infrastructure.Dto.Rubikscube;
using RubiksCubeApi.Models.Enums;

namespace RubiksCubeApi.Application.Commands
{
    public class RotateRubiksCubeCommandHandler : BaseCommandHandler<RotateRubiksCubeCommand, RubiksCubeDto>
    {
        private readonly IRubiksCubeRotator _rotator;
        private readonly ILogger<CreateRubiksCubeCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public RotateRubiksCubeCommandHandler(
            IRubiksCubeRotator rotator,
            ILogger<CreateRubiksCubeCommandHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _rotator = rotator ?? throw new ArgumentNullException(nameof(IRubiksCubeFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(ILogger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));
        }

        public override async Task<RubiksCubeDto> Handle(RotateRubiksCubeCommand command, CancellationToken cancellationToken)
        {
            var cube = await _unitOfWork.RubiksCubeRepository.GetByIdAsync(command.Id, cancellationToken);

            if (cube == null) 
            {
                throw new ArgumentNullException(nameof(cube));
            }
            _rotator.Rotate(cube, command.RotateCubeDto.FaceRubikToRotate, command.RotateCubeDto.RubiksRotation);
            _unitOfWork.RubiksCubeRepository.Update(cube);

            var rubiksCubeDto = new RubiksCubeDto(cube);
            
            _logger.LogInformation(cube.StringCubeExploded());

            await _unitOfWork.CommitAsync();

            return rubiksCubeDto;
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using RubiksCubeApi.Application.Commands;
using RubiksCubeApi.Application.Queries;
using RubiksCubeApi.Domain.Entities;
using RubiksCubeApi.Infrastructure.Dto.Rubikscube;
using RubiksCubeApi.Models;

namespace RubiksCubeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RubikController : Controller
    {
        private readonly ILogger<RubikController> _logger;
        private readonly IMediator _mediator;

        public RubikController(ILogger<RubikController> logger, IMediator mediator) 
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(RubiksCubeDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateRubiksCube()
        {
            var rubiksCube = await _mediator.Send(new CreateRubiksCubeCommand());

            return Ok(rubiksCube);
        }

        [HttpPost("rotate/{cubeId}")]
        [ProducesResponseType(typeof(RubiksCubeDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateRubiksCube(Guid cubeId, [FromBody] RotateCubeDto rotateCubeDto)
        {
            var rubiksCube = await _mediator.Send(new RotateRubiksCubeCommand()
            {
                Id = cubeId,
                RotateCubeDto = rotateCubeDto
            });

            return Ok(rubiksCube);
        }

        [HttpGet("{cubeId}")]
        [ProducesResponseType(typeof(RubiksCubeDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRubiksCubeById(Guid cubeId)
        {
            var rubiksCube = await _mediator.Send(new GetRubiksCubeByIdQuery()
            {
                CubeId = cubeId,
            });

            return Ok(rubiksCube);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<RubiksCubeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRubiksCubesAll()
        {
            var rubiksCubesAll = await _mediator.Send(new GetRubiksCubesAllQuery()
            {
            });

            return Ok(rubiksCubesAll);
        }
    }


}

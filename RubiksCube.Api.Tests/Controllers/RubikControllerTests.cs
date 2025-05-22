using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RubiksCubeApi.Application.Commands;
using RubiksCubeApi.Application.Queries;
using RubiksCubeApi.Controllers;
using RubiksCubeApi.Infrastructure.Dto.Rubikscube;
using RubiksCubeApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCube.Api.Tests.Controllers
{
    public class RubikControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<RubikController>> _loggerMock;
        private readonly RubikController _controller;

        public RubikControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<RubikController>>();
            _controller = new RubikController(_loggerMock.Object, _mediatorMock.Object);
        }

        [Fact]
        public async Task CreateRubiksCube_ShouldReturnOkWithResult()
        {
            // Arrange
            var expected = new RubiksCubeDto { Id = Guid.NewGuid() };
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateRubiksCubeCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            // Act
            var result = await _controller.CreateRubiksCube();

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task RotateRubiksCube_ShouldReturnOkWithRotatedCube()
        {
            // Arrange
            var cubeId = Guid.NewGuid();
            var rotateDto = new RotateCubeDto { FaceRubikToRotate = FaceRubik.Up, RubiksRotation = RotationRubik.Clockwise };
            var expected = new RubiksCubeDto { Id = cubeId };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<RotateRubiksCubeCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            // Act
            var result = await _controller.CreateRubiksCube(cubeId, rotateDto);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetRubiksCubeById_ShouldReturnOkWithCube()
        {
            // Arrange
            var cubeId = Guid.NewGuid();
            var expected = new RubiksCubeDto { Id = cubeId };

            _mediatorMock
                .Setup(m => m.Send(It.Is<GetRubiksCubeByIdQuery>(q => q.CubeId == cubeId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            // Act
            var result = await _controller.GetRubiksCubeById(cubeId);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetRubiksCubesAll_ShouldReturnOkWithList()
        {
            // Arrange
            var cubes = new List<RubiksCubeDto>
        {
            new RubiksCubeDto { Id = Guid.NewGuid() },
            new RubiksCubeDto { Id = Guid.NewGuid() }
        };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetRubiksCubesAllQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cubes);

            // Act
            var result = await _controller.GetRubiksCubesAll();

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().BeEquivalentTo(cubes);
        }

    }
}

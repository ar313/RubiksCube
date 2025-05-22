using FluentAssertions;
using RubiksCubeApi.Application.Factories;
using RubiksCubeApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCube.Api.Tests.Factories
{
    public class RubiksCubeFactoryTests
    {
        [Fact]
        public void Create_ShouldGenerateValidRubiksCube()
        {
            // Arrange
            var factory = new RubiksCubeFactory();

            // Act
            var cube = factory.Create();

            // Assert
            cube.Should().NotBeNull();
            cube.RubiksBoxes.Should().HaveCount(54); // 6 faces * 9 boxes

            foreach (FaceRubik face in Enum.GetValues(typeof(FaceRubik)))
            {
                var boxes = cube.RubiksBoxes.Where(b => b.Face == face).ToList();

                boxes.Should().HaveCount(9); // 3x3

                boxes.All(b => b.Color == (ColorRubik)face).Should().BeTrue("Each face should have consistent color");

                var rows = boxes.Select(b => b.Row).Distinct().ToList();
                var cols = boxes.Select(b => b.Column).Distinct().ToList();

                rows.Should().BeEquivalentTo(new[] { 0, 1, 2 });
                cols.Should().BeEquivalentTo(new[] { 0, 1, 2 });
            }
        }
    }
}

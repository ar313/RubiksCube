using RubiksCubeApi.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RubiksCubeApi.Infrastructure.Dto.Rubikscube
{
    public class RubiksCubeDto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public List<RubiksBoxDto> RubiksBoxesDto { get; set; } = new();

        public RubiksCubeDto() { }
        public RubiksCubeDto(RubiksCube rubiksCube)
        {

            this.Id = rubiksCube.Id;

            this.RubiksBoxesDto = rubiksCube.RubiksBoxes.Select(rb => new RubiksBoxDto()
            {
                Color = rb.Color,
                Column = rb.Column,
                Face = rb.Face,
                RubiksCubeId = rb.RubiksCubeId,
                Id = rb.Id,
                Row = rb.Row,
            }).ToList();
        }
    }
}

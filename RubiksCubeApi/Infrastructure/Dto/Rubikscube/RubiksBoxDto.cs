using RubiksCubeApi.Domain.Entities;
using RubiksCubeApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RubiksCubeApi.Infrastructure.Dto.Rubikscube
{
    public class RubiksBoxDto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public FaceRubik Face { get; set; }
        public int Row { get; set; }     // 0 to 2
        public int Column { get; set; }  // 0 to 2
        public ColorRubik Color { get; set; }
        public Guid RubiksCubeId { get; set; }
    }
}

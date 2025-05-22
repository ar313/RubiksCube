using RubiksCubeApi.Models.Enums;
using System.Drawing;
using System.Text.Json.Serialization;

namespace RubiksCubeApi.Domain.Entities
{
    public class RubiksBox
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public FaceRubik Face { get; set; }
        public int Row { get; set; }     // 0 to 2
        public int Column { get; set; }  // 0 to 2
        public ColorRubik Color { get; set; }

        public Guid RubiksCubeId { get; set; }

        [JsonIgnore]
        public RubiksCube RubiksCube { get; set; }
    }
}

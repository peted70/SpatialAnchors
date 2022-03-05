using System.ComponentModel.DataAnnotations;

namespace SpatialAnchors
{
    public class AnchorData
    {
        public DateTime Created { get; set; }

        [NotDefault]
        [Required]
        public Guid AnchorId { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}

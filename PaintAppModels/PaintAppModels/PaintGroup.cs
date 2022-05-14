using System.ComponentModel.DataAnnotations.Schema;

namespace PaintAppModels
{
    public class PaintGroup
    {
        public Guid PaintGroupId { get; set; }
        public Guid ManufacturerId { get; set; }
        public string PaintGroupName { get; set; }
        public string PaintGroupDescription { get; set; }

        [NotMapped]
        public string ManufacturerName { get; set; }

    }
}

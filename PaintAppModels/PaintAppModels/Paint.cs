using System.ComponentModel.DataAnnotations.Schema;

namespace PaintAppModels
{
    public class Paint
    {
        public Guid PaintId { get; set; }
        public Guid GroupId { get; set; }
        public string PaintName { get; set; }
        public int PaintSize { get; set; }
        public string StockImageURL { get; set; }
        public decimal MSRP { get; set; }

        [NotMapped]
        public string PaintGroupName { get; set; }

        [NotMapped]
        public bool InCollection { get; set; }
    }
}

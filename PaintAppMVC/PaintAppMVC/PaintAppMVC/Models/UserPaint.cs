using System.ComponentModel.DataAnnotations.Schema;

namespace PaintAppModels
{
    public class UserPaint
    {
        public Guid UserPaintId { get; set; }
        public Guid UserId { get; set; }
        public Guid PaintId { get; set; }
        public DateTime DateCreated { get; set; }
        [NotMapped]
        public string UserName { get; set; }
        [NotMapped]
        public string PaintName { get; set; }
    }
}

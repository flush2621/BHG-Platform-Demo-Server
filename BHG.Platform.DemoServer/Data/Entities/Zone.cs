using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BHG.Platform.DemoServer.Data.Entities
{
    public class Zone
    {
        [Key]
        [Column(TypeName = "varchar(6)")]
        public string Id { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        public string Description { get; set; }
    }
}

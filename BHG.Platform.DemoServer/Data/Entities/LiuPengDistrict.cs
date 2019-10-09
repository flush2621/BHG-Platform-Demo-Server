using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BHG.Platform.DemoServer.Data.Entities
{
    public class LiuPengDistrict
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        public int LiuPengRegionId { get; set; }
        [Column(TypeName = "varchar(120)")]
        [Required]
        public string Name { get; set; }
        public ICollection<LiuPengLocation> LiuPengLocations { get; set; }
    }
}

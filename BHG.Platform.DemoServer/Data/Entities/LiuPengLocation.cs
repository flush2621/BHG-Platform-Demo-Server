using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BHG.Platform.DemoServer.Data.Entities
{
    public class LiuPengLocation
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        public int LiuPengDistrictId { get; set; }
        [Column(TypeName = "char(1)")]
        [Required]
        public string Type { get; set; }
        [Column(TypeName = "varchar(120)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "int(11)")]
        public int? PhysicalId { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Address { get; set; }
        [Column(TypeName = "varchar(120)")]
        public string ManagerName { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string ManagerPhone { get; set; }
        [Column(TypeName = "varchar(120)")]
        public string ContactName { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string ContactPhone { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Printer { get; set; }
    }
}

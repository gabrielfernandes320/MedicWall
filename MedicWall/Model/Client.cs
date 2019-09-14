using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MedicWall.Model
{
    [Table("client")]
    public class Client
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public int password { get; set; }
        public int role { get; set; }
        public int cellPhone { get; set; }
    }
}
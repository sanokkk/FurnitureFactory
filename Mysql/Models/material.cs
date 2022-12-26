using System.ComponentModel.DataAnnotations;

namespace Mysql.Models
{
    public class material
    {
        [Key]
        public int id_material { get; private set; }

        public string name_material { get; set; }
    }
}

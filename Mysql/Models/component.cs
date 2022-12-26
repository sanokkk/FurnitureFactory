using System.ComponentModel.DataAnnotations;

namespace Mysql.Models
{
    public class component
    {
        [Key]
        public int id_component { get; private set; }

        public string name_component { get; set; }

        [Range(0,1000000, ErrorMessage ="Недопустимое количество")]
        public int quantity { get; set; }

        [Range(1, 12, ErrorMessage ="Несуществующий материал")]
        public int id_material { get; set; }
    }
}

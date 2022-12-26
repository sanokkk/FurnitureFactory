using System.ComponentModel.DataAnnotations;

namespace Mysql.Models
{
    public class defectMaterial
    {
        [Key]
        public int id_defectMaterial { get; private set; }
        [Required(ErrorMessage ="Введите количество")]
        public int quantity { get; set; }

        [Range(1,10, ErrorMessage ="Введите число от 1 до 10")]
        public int id_material { get; set; }

    }
}

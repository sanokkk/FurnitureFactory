using System.ComponentModel.DataAnnotations;

namespace Mysql.Models
{
    public class machine
    {
        [Key]
        public int id_machine { get; private set; }
        [Range(1,3,ErrorMessage ="Введите число от 1 до 3")]
        public int id_purpose { get; set; }
    }
}

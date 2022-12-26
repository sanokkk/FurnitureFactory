using System.ComponentModel.DataAnnotations;

namespace Mysql.Models
{
    public class employee
    {
        [Key]
        public int id_employee { get; private set; }

        [Range(1,3, ErrorMessage ="Введите число в диапазоне от 1 до 3")]
        public int id_purpose { get; set; }

        public string name { get; set; }
    }
}
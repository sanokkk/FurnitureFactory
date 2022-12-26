using System.ComponentModel.DataAnnotations;

namespace Mysql.Models
{
    public class employee_purpose
    {
        [Key]
        public int id_purpose { get; private set; }

        public string purpose { get; set; }
    }
}
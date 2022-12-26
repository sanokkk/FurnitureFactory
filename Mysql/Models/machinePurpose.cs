using System.ComponentModel.DataAnnotations;

namespace Mysql.Models
{
    public class machinePurpose
    {
        [Key]
        public int id_purpose { get; private set; }

        public string purpose { get; set; }

        [Range(0, 1000000, ErrorMessage ="Неверная сумма")]
        public int price { get; set; }
    }
}

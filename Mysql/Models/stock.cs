using System.ComponentModel.DataAnnotations;

namespace Mysql.Models
{
    public class stock
    {
        [Key]
        public int id_stock { get; private set; }

        [Required]
        public string stock_adress { get; set; }

        [Required]
        public int id_readyFurniture { get; set; }
    }
}

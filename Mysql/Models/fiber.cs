using System.ComponentModel.DataAnnotations;

namespace Mysql.Models
{
    public class fiber
    {
        [Key]
        public int id_fiber { get; private set; }

        public string name_fiber { get; set; }
    }
}

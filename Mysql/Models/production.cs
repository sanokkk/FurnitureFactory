using Mysql.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Mysql.Models
{
    public class production
    {
        [Key]
        public int id_plan { get; private set; }

        [Required(ErrorMessage ="Обязательное поле")]
        public int id_machine { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public int id_stock { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public int id_employee { get; set; }

    }
}

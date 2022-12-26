using System.ComponentModel.DataAnnotations;

namespace Mysql.Models
{
    public class readyComponent
    {
        [Key]
        public int id_readyFurniture { get; private set; }

        public string name_readyFurniture { get; set; }

        [Range(1,12, ErrorMessage ="Несуществующий компонент")]
        public int id_component { get; set; }

        [Range(1, 11, ErrorMessage ="Несуществующая ткань")]
        public int id_fiber { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Mysql.Models
{
    public class test
    {
        [Key]
        public int id_test { get; private set; }

        public string name { get; set; }
    }
}
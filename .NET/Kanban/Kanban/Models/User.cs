using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kanban.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }

        [Required]
        public string emailAdress { get; set; }

        [Required]
        public string password { get; set; }


    }
}

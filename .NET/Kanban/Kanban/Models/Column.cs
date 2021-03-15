using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kanban.Models
{
    public class Column
    {
        [Key]
        public int ColumnId { get; set; }

        [Required]
        public string Name { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Models
{
    public class KanbanPost
    {
        [Key]
        public int KanbanId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required ]
        public Column Column { get; set; }

        [Required] 
        public Note Note { get; set; }

    }
}

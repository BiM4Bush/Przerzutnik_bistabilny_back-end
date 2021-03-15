using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kanban.Models;

namespace Kanban.Data
{
    public class KanbanContext : DbContext
    {
        public KanbanContext (DbContextOptions<KanbanContext> options)
            : base(options)
        {
        }

        public DbSet<Kanban.Models.KanbanPost> Kanban { get; set; }
    }
}

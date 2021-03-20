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

        public DbSet<Kanban.Models.KanbanBoard> Kanban { get; set; }

        public DbSet<Kanban.Models.Person> Person { get; set; }

        public DbSet<Kanban.Models.Note> Note { get; set; }

        public DbSet<Kanban.Models.Column> Column { get; set; }

        public DbSet<Kanban.Models.User> User { get; set; }
    }
}

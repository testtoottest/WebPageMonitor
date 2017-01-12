using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorStron.Database
{
    class MonitorContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }
        public DbSet<PersistedContent> PersistedContents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Page>().HasKey(x => x.PageId);
            modelBuilder.Entity<Page>().HasMany(x => x.PersistedContents)
                                          .WithRequired(x => x.WebPage)
                                          .HasForeignKey(x => x.PageId);

            modelBuilder.Entity<PersistedContent>().HasKey(x => x.PersistedContentId);
        }
    }
}

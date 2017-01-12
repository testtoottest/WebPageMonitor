using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageMonitor.Models
{
    class MonitorContext : DbContext
    {
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Change> Changes { get; set; }
        public virtual DbSet<PageUserMapping> PageUserMappings { get; set; }
        public virtual DbSet<ChangeInfo> ChangeInfos { get; set; }
        public virtual DbSet<Opinion> Opinions { get; set; }
        public virtual DbSet<Mail> Mails { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Page>().HasKey(x => x.PageId);
            modelBuilder.Entity<Page>().HasMany(x => x.Changes)
                                            .WithRequired(x => x.Page)
                                            .HasForeignKey(x => x.PageId);
            modelBuilder.Entity<Page>().HasMany(x => x.UrlUserMappings)
                                            .WithRequired(x => x.Page)
                                            .HasForeignKey(x => x.PageId)
                                            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Change>().HasKey(x => x.ChangeId);
            modelBuilder.Entity<Change>().HasMany(x => x.ChangeInfos)
                                            .WithRequired(x => x.Change)
                                            .HasForeignKey(x => x.ChangeId);
            modelBuilder.Entity<Change>().HasMany(x => x.Opinions)
                                            .WithRequired(x => x.Change)
                                            .HasForeignKey(x => x.ChangeId);

            modelBuilder.Entity<ChangeInfo>().HasKey(x => x.ChangeInfoId);

            modelBuilder.Entity<PageUserMapping>().HasKey(x => x.PageUserMappingId);
            modelBuilder.Entity<PageUserMapping>().HasMany(x => x.Opinions)
                                                    .WithRequired(x => x.PageUserMapping)
                                                    .HasForeignKey(x => x.PageUserMappingId);
            modelBuilder.Entity<PageUserMapping>().HasMany(x => x.Rates)
                                                    .WithRequired(x => x.PageUserMapping)
                                                    .HasForeignKey(x => x.PageUserMappingId);

            modelBuilder.Entity<Opinion>().HasKey(x => x.OpinionId);

            modelBuilder.Entity<Rate>().HasKey(x => x.RateId);

            modelBuilder.Entity<User>().HasKey(x => x.UserId);
            modelBuilder.Entity<User>().HasMany(x => x.PageUserMappings)
                                            .WithRequired(x => x.User)
                                            .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<User>().HasMany(x => x.Mails)
                                            .WithRequired(x => x.User)
                                            .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<User>().HasMany(x => x.Phones)
                                            .WithRequired(x => x.User)
                                            .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Mail>().HasKey(x => x.MailAddress);

            modelBuilder.Entity<Phone>().HasKey(x => x.PhoneNumber);
        }
    }
}

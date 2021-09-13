using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AppDbContext : IdentityDbContext<User, Role, long, IdentityUserClaim<long>, UserRole, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRole>(userRole =>
            {
                userRole.ToTable("UserRoles");
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
            builder.Entity<IdentityUserLogin<long>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<long>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserClaim<long>>().ToTable("UserClaims");
            builder.Entity<IdentityUserToken<long>>().ToTable("UserTokens");

            builder.Entity<Post>().
                HasOne(x => x.User).
                WithMany(x => x.Posts).
                HasForeignKey(x => x.UserId).
                OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Post>().
                HasMany(x => x.Comments).
                WithOne(x => x.Post).
                HasForeignKey(x => x.PostId).
                OnDelete(DeleteBehavior.Restrict);
            builder.Entity<User>().
                HasMany(x => x.Comments).
                WithOne(x => x.User).
                HasForeignKey(x => x.UserId).
                OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Post>().
                HasMany(x => x.Liked).
                WithOne(x => x.Post).
                HasForeignKey(x => x.PostId).
                OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Liked>().
                HasOne(x => x.User).
                WithMany(x => x.Liked).
                HasForeignKey(x => x.UserId).
                OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Payments>().
                HasOne(x => x.User).
                WithMany(x => x.Payments).
                HasForeignKey(x => x.UserId).
                OnDelete(DeleteBehavior.Restrict);
            builder.Entity<User>().
                HasMany(x => x.Follower).
                WithOne(x => x.FollowerUser).
                HasForeignKey(x => x.FollowerUserId).
                OnDelete(DeleteBehavior.Restrict);
            builder.Entity<User>().
                HasMany(x => x.Followed).
                WithOne(x => x.FollowedUser).
                HasForeignKey(x => x.FollowedUserId).
                OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Wallet>().
                HasOne(x => x.User).
                WithMany(x => x.Wallets).
                HasForeignKey(x => x.UserId).
                OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Ticket>().
                HasOne(x => x.User).
                WithMany(x => x.Tickets).
                HasForeignKey(x => x.UserId).
                OnDelete(DeleteBehavior.Restrict);
            builder.Entity<TicketDetails>().
                HasOne(x => x.Ticket).
                WithMany(x => x.TicketDetails).
                HasForeignKey(x => x.TicketId).
                OnDelete(DeleteBehavior.Restrict);
            builder.Entity<TicketAttachment>().
                HasOne(x => x.TicketDetails).
                WithMany(x => x.TicketAttachments).
                HasForeignKey(x => x.TicketDetailsId).
                OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Trade>().
                HasOne(x => x.User).
                WithMany(x => x.Trades).
                HasForeignKey(x => x.UserId).
                OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Trade>().
                HasOne(x => x.FromCoin).
                WithMany(x => x.FromTrade).
                HasForeignKey(x => x.FromCoinId).
                OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Trade>().
                HasOne(x => x.ToCoin).
                WithMany(x => x.ToTrade).
                HasForeignKey(x => x.ToCoinId).
                OnDelete(DeleteBehavior.Restrict);
        }
        public virtual DbSet<Coin> Coins { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Configurations> Configurations { get; set; }
        public virtual DbSet<Liked> Liked { get; set; }
        public virtual Payments Payments { get; set; }
        public virtual Post Post { get; set; }
        public virtual Relevance Relevance { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual TicketAttachment TicketAttachment { get; set; }
        public virtual TicketDetails TicketDetails { get; set; }
        public virtual Trade Trade { get; set; }
        public virtual User User { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual Wallet Wallet { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace Hapy.DB
{
    public class HapyDBContext : DbContext
    {
        public HapyDBContext() : base("name=HapyContextConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<HapyDBContext>(null);
            if (!base.Database.Exists())
            {
                Database.SetInitializer<HapyDBContext>(new CreateDatabaseIfNotExists<HapyDBContext>());
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
        }


        public DbSet<Post> Post { get; set; }
        public DbSet<Share> Share { get; set; }
        public DbSet<FToken> FToken { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<NewsAPI> NewsAPI { get; set; }
        public DbSet<Logging> Logging { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<PostView> PostView { get; set; }
        public DbSet<PostLike> PostLike { get; set; }
        public DbSet<UsersInfo> UsersInfo { get; set; }
        public DbSet<CompDetail> CompDetail { get; set; }
        public DbSet<SubComment> SubComment { get; set; }
        public DbSet<ChatMessage> ChatMessage { get; set; }
        public DbSet<UserCompDetail> UserCompDetail { get; set; }
        public DbSet<LocationDetail> LocationDetail { get; set; }
        public DbSet<OTPVerification> OTPVerification { get; set; }
        public DbSet<AppUserSettings> AppUserSettings { get; set; }
        public DbSet<CallChatSetting> CallChatSestting { get; set; }
        public DbSet<RecordActionTimes> RecordActionTimes { get; set; }
        public DbSet<UserConnectRequest> UserConnectRequest { get; set; }
        public DbSet<UnRegisterdDevices> UnRegisterdDevices { get; set; }



        public void DbContextInitialization()
        {

        }
    }
}

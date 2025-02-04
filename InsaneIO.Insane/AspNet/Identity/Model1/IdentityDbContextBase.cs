﻿using InsaneIO.Insane.AspNet.Identity.Model1.Configuration;
using InsaneIO.Insane.AspNet.Identity.Model1.Entity;
using System.Runtime.Versioning;

namespace InsaneIO.Insane.AspNet.Identity.Model1
{
    [RequiresPreviewFeatures]
    public abstract class IdentityDbContextLongBase : IdentityDbContextBase<long>
    {
        public IdentityDbContextLongBase(DbContextOptions options) : base(options)
        {
        }
    }
    [RequiresPreviewFeatures]
    public abstract class IdentityDbContextStringBase : IdentityDbContextBase<string>
    {
        public IdentityDbContextStringBase(DbContextOptions options) : base(options)
        {
        }
    }

    [RequiresPreviewFeatures]
    public abstract class IdentityDbContextBase<TKey> : IdentityDbContextBase<TKey, IdentityUser<TKey>, IdentityRole<TKey>, IdentityAccess<TKey>, IdentityUserClaim<TKey>, IdentityPlatform<TKey>, IdentitySession<TKey>, IdentityUserRecoveryCode<TKey>, IdentityLog<TKey>,
        IdentityUserConfiguration<TKey>, IdentityRoleConfiguration<TKey>, IdentityAccessConfiguration<TKey>, IdentityUserClaimConfiguration<TKey>, IdentityPlatformConfiguration<TKey>, IdentitySessionConfiguration<TKey>, IdentityUserRecoveryCodeConfiguration<TKey>, IdentityLogConfiguration<TKey>>
        where TKey : IEquatable<TKey>
    {
        public IdentityDbContextBase(DbContextOptions options) : base(options)
        {
        }
    }

    [RequiresPreviewFeatures]
    public abstract class IdentityDbContextBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog,
        TUserConfiguration, TRoleConfiguration, TAccessConfiguration, TUserClaimConfiguration, TPlatformConfiguration, TSessionConfiguration, TRecoveryCodeConfiguration, TLogConfiguration> : CoreDbContextBase
       where TKey : IEquatable<TKey>
        where TUser : IdentityUserBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TRole : IdentityRoleBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TAccess : IdentityAccessBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TUserClaim : IdentityUserClaimBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TPlatform : IdentityPlatformBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TSession : IdentitySessionBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TRecoveryCode : IdentityUserRecoveryCodeBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TLog : IdentityLogBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TUserConfiguration : IdentityUserConfigurationBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TRoleConfiguration : IdentityRoleConfigurationBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TAccessConfiguration : IdentityAccessConfigurationBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TUserClaimConfiguration : IdentityUserClaimConfigurationBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TPlatformConfiguration : IdentityPlatformConfigurationBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TSessionConfiguration : IdentitySessionConfigurationBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TRecoveryCodeConfiguration : IdentityUserRecoveryCodeConfigurationBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TLogConfiguration : IdentityLogConfigurationBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
    {

        public DbSet<TUser> Users { get; set; } = null!;
        public DbSet<TRole> Roles { get; set; } = null!;
        public DbSet<TAccess> Accesses { get; set; } = null!;
        public DbSet<TUserClaim> UserClaims { get; set; } = null!;
        public DbSet<TPlatform> Platforms { get; set; } = null!;
        public DbSet<TSession> Sessions { get; set; } = null!;
        public DbSet<TRecoveryCode> RecoveryCodes { get; set; } = null!;
        public DbSet<TLog> Logs { get; set; } = null!;

        public IdentityDbContextBase(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration((TUserConfiguration)Activator.CreateInstance(typeof(TUserConfiguration), new object[] { Database })!);
            builder.ApplyConfiguration((TRoleConfiguration)Activator.CreateInstance(typeof(TRoleConfiguration), new object[] { Database })!);
            builder.ApplyConfiguration((TAccessConfiguration)Activator.CreateInstance(typeof(TAccessConfiguration), new object[] { Database })!);
            builder.ApplyConfiguration((TUserClaimConfiguration)Activator.CreateInstance(typeof(TUserClaimConfiguration), new object[] { Database })!);
            builder.ApplyConfiguration((TPlatformConfiguration)Activator.CreateInstance(typeof(TPlatformConfiguration), new object[] { Database })!);
            builder.ApplyConfiguration((TSessionConfiguration)Activator.CreateInstance(typeof(TSessionConfiguration), new object[] { Database })!);
            builder.ApplyConfiguration((TRecoveryCodeConfiguration)Activator.CreateInstance(typeof(TRecoveryCodeConfiguration), new object[] { Database })!);
            builder.ApplyConfiguration((TLogConfiguration)Activator.CreateInstance(typeof(TLogConfiguration), new object[] { Database })!);
        }
    }
}

﻿using InsaneIO.Insane.AspNet.Identity.Model1.Entity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.Versioning;

namespace InsaneIO.Insane.AspNet.Identity.Model1.Configuration
{
    [RequiresPreviewFeatures]
    public class IdentityRoleConfiguration : IdentityRoleConfiguration<long>
    {
        public IdentityRoleConfiguration(DatabaseFacade database, string? schema = null) : base(database)
        {
        }
    }

    [RequiresPreviewFeatures]
    public class IdentityRoleConfiguration<TKey> : IdentityRoleConfigurationBase<TKey, IdentityUser<TKey>, IdentityRole<TKey>, IdentityAccess<TKey>, IdentityUserClaim<TKey>, IdentityPlatform<TKey>, IdentitySession<TKey>, IdentityUserRecoveryCode<TKey>, IdentityLog<TKey>>
        where TKey : IEquatable<TKey>
    {
        public IdentityRoleConfiguration(DatabaseFacade database) : base(database)
        {
        }
    }

    [RequiresPreviewFeatures]
    public abstract class IdentityRoleConfigurationBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog> : EntityTypeConfigurationBase<TRole>
       where TKey : IEquatable<TKey>
        where TUser : IdentityUserBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TRole : IdentityRoleBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TAccess : IdentityAccessBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TUserClaim : IdentityUserClaimBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TPlatform : IdentityPlatformBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TSession : IdentitySessionBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TRecoveryCode : IdentityUserRecoveryCodeBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
        where TLog : IdentityLogBase<TKey, TUser, TRole, TAccess, TUserClaim, TPlatform, TSession, TRecoveryCode, TLog>
    {
        public IdentityRoleConfigurationBase(DatabaseFacade database) : base(database)
        {
        }

        public override void Configure(EntityTypeBuilder<TRole> builder)
        {
            builder.ToTable(Database);

            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd(Database, builder, startsAt: Constants.IdentityColumnStartValue);
            builder.Ignore(e => e.UniqueId);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(Constants.NameMaxLength).IsConcurrencyToken();
            builder.Property(e => e.Description).IsRequired(false).HasMaxLength(Constants.DescriptionMaxLength);
            builder.Property(e => e.LogoUri).IsRequired(false).HasMaxLength(Constants.UriMaxLength);
            builder.Property(e => e.CreatedAt).IsRequired();
            builder.Property(e => e.Enabled).IsRequired().IsConcurrencyToken().IsConcurrencyToken();
            builder.Property(e => e.ActiveUntil).IsRequired(false).IsConcurrencyToken();

            builder.HasPrimaryKeyIndex(Database, e => e.Id);
            builder.HasUniqueIndex(Database, e => e.Name);
        }
    }
}

using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Data.EntityTypeConfigurations
{
    public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(o => o.FrontChannelLogoutSessionRequired).HasColumnName("FChannelLogoutSessionRequired");
            builder.Property(o => o.BackChannelLogoutSessionRequired).HasColumnName("BChannelLogoutSessionRequired");
            builder.Property(o => o.AlwaysIncludeUserClaimsInIdToken).HasColumnName("AIncludeUserClaimsInIdToken");
            builder.Property(o => o.UpdateAccessTokenClaimsOnRefresh).HasColumnName("UAccessTokenClaimsOnRefresh");
        }
    }
}

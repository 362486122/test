using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.EntityTypeConfigurations;

namespace Test.Data
{
    public class ConfigurationDBContextImpl : ConfigurationDbContext<ConfigurationDBContextImpl>
    {
        public ConfigurationDBContextImpl(DbContextOptions<ConfigurationDBContextImpl> options, ConfigurationStoreOptions storeOptions) : base(options, storeOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

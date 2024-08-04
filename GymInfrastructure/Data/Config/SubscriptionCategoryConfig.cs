using GymCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymInfrastructure.Data.Config
{
    public class SubscriptionCategoryConfig : IEntityTypeConfiguration<SubscriptionCategory>
    {
        public void Configure(EntityTypeBuilder<SubscriptionCategory> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p=> p.Description).HasMaxLength(500);
            builder.Property(p => p.Price).IsRequired();
        }
    }
}

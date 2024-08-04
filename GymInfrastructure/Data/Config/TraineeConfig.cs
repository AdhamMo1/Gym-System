using GymCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymInfrastructure.Data.Config
{
    public class TraineeConfig : IEntityTypeConfiguration<Trainee>
    {
        public void Configure(EntityTypeBuilder<Trainee> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Gender).HasMaxLength(10);
            builder.Property(p => p.Phone).HasMaxLength(20);
            builder.HasMany(p => p.Attendences).WithOne(p => p.Trainee);
            builder.HasOne(p => p.subscriptionCategory).WithMany().HasForeignKey(p=>p.SCId);
        }
    }
}

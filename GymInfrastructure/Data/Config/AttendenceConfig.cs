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
    public class AttendenceConfig : IEntityTypeConfiguration<Attendence>
    {
        public void Configure(EntityTypeBuilder<Attendence> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Trainee).WithMany().HasForeignKey(p => p.TraineeId);
            builder.Property(p=>p.TraineeId).HasMaxLength(50);
        }
    }
}

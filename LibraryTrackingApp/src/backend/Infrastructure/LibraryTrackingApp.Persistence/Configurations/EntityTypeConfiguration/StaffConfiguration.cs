﻿using LibraryTrackingApp.Domain.Entities.Library;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryTrackingApp.Persistence.Configurations.EntityTypeConfiguration;

public class StaffConfiguration : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.ToTable("Staff"); 
        builder.HasKey(s => s.Id); 

 
        builder.Property(s => s.Phone).IsRequired();
        builder.Property(s => s.Address).IsRequired();
        builder.Property(s => s.EmploymentDate).IsRequired();
        builder.Property(s => s.Salary).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(s => s.IsFullTime).IsRequired();

        // Kullanıcıya ait staff ilişkisi
        builder.HasOne(s => s.User)
               .WithOne(u => u.Staff)
               .HasForeignKey<Staff>(s => s.UserId);
    }
}

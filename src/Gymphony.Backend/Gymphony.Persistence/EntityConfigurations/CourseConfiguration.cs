using Gymphony.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymphony.Persistence.EntityConfigurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(course => course.Capacity).IsRequired();
        builder.Property(course => course.SessionDurationInMinutes).IsRequired();
        builder.Property(course => course.EnrollmentsCountPerWeek).IsRequired();
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyFisrtProjectASPNETZERO.Tasks.Configuration
{
    public class TaskEntityConfiguration
    {
        public const int TitleMaxLength = 256;
        public const int DescriptionMaxLength = 64*1024;

        public static void Configure(EntityTypeBuilder<Task> entityBuilder)
        {
            entityBuilder.ToTable("Tasks");
            entityBuilder.Property(e => e.Title).IsRequired().HasMaxLength(TitleMaxLength);
            entityBuilder.Property(e => e.Description).HasMaxLength(DescriptionMaxLength);
        }
    }
}

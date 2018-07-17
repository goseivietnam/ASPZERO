using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyFisrtProjectASPNETZERO.Employee1.Configuration
{
    public class EmployeeEntityConfiguration
    {
        public const int NameMaxLenght = 32;
        public static void Configure(EntityTypeBuilder<Employee> entityBuilder)
        {
            entityBuilder.ToTable("Employee");
            entityBuilder.Property(x=>x.Name).IsRequired().HasMaxLength(NameMaxLenght);
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LED.Domain.Entities;

namespace LED.DataProvider.Mapping
{
    public class t_orgMap : EntityTypeConfiguration<t_org>
    {
        public t_orgMap()
        {
            // Primary Key
            this.HasKey(t => t.orgcode);

            // Properties
            this.Property(t => t.orgcode)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("t_org", "led");
            this.Property(t => t.orgcode).HasColumnName("orgcode");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.parentCode).HasColumnName("parentCode");
            this.Property(t => t.orgtype).HasColumnName("orgtype");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LED.Domain.Entities;

namespace LED.DataProvider.Mapping
{
    public class t_roleMap : EntityTypeConfiguration<t_role>
    {
        public t_roleMap()
        {
            // Primary Key
            this.HasKey(t => t.roleid);

            this.Property(t => t.roleid)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Properties
            this.Property(t => t.rolename)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("t_role", "led");
            this.Property(t => t.roleid).HasColumnName("roleid");
            this.Property(t => t.rolename).HasColumnName("rolename");

        }
    }
}

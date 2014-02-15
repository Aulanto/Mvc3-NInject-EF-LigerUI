using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LED.Domain.Entities;

namespace LED.DataProvider.Mapping
{
    public class t_resourcesMap : EntityTypeConfiguration<t_resources>
    {
        public t_resourcesMap()
        {
            // Primary Key
            this.HasKey(t => t.rid);

            // Properties
            this.Property(t => t.resources)
                .HasMaxLength(60);

            this.Property(t => t.url)
                .HasMaxLength(60);

            // Table & Column Mappings
            this.ToTable("t_resources", "led");
            this.Property(t => t.rid).HasColumnName("rid");
            this.Property(t => t.resources).HasColumnName("resources");
            this.Property(t => t.url).HasColumnName("url");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.tindex).HasColumnName("tindex");
            this.Property(t => t.parentrid).HasColumnName("parentrid");
            this.Property(t => t.name).HasColumnName("name");

            this.HasMany(m => m.role).WithMany(m=>m.t_resources).Map(m =>
            {
                m.MapLeftKey("rid");
                m.MapRightKey("roleid");
                m.ToTable("role_rights","led");
            });
        }
    }
}

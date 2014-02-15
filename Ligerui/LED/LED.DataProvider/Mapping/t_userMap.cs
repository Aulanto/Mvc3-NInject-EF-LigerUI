using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LED.Domain.Entities;

namespace LED.DataProvider.Mapping
{
    public class t_userMap : EntityTypeConfiguration<t_user>
    {
        public t_userMap()
        {
            // Primary Key
            this.HasKey(t => t.userid);

            // Properties
            this.Property(t => t.userid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("t_user", "led");
            this.Property(t => t.userid).HasColumnName("userid");
            this.Property(t => t.loginuser).HasColumnName("loginuser");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.orgcode).HasColumnName("orgcode");
            this.Property(t => t.password).HasColumnName("password");

            this.HasOptional(m => m.org).WithMany().HasForeignKey(m => m.orgcode);
            this.HasMany(m => m.role).WithMany(m=>m.t_user).Map(m =>
            {
                m.MapLeftKey("userid");
                m.MapRightKey("roleid");
                m.ToTable("role_user","led");
            });

        }
    }
}

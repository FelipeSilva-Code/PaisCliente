using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoCometrix.Data.Database.Configurations
{
    internal class PaisConfiguration : EntityTypeConfiguration<PaisEntity>
    {
        public PaisConfiguration() : base(tableName: "TB_PAIS")
        {

        }

        public override void OnConfigure(EntityTypeBuilder<PaisEntity> builder)
        {
            builder.Property(x => x.Nome)
                .HasColumnName("DS_NOME");
        }
    }
}

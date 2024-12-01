using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoCometrix.Data.Database.Configurations
{
    internal class ClienteConfiguration : EntityTypeConfiguration<ClienteEntity>
    {
        public ClienteConfiguration() : base (tableName: "TB_CLIENTE")
        {
        }

        public override void OnConfigure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.Property(x => x.Nome)
                .HasColumnName("DS_NOME");

            builder.Property(x => x.FkPais)
                .HasColumnName("FK_PAIS");

            builder.HasOne(x => x.Pais)
                .WithMany()
                .HasForeignKey(x => x.FkPais);
        }
    }
}

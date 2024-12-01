using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public abstract class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : DefaultEntity
{
    private readonly string tableName;

    public EntityTypeConfiguration(string tableName)
    {
        this.tableName = tableName;
    }

    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.ToTable(this.tableName);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("PK_ID").UseIdentityColumn();
        this.OnConfigure(builder);
    }

    public abstract void OnConfigure(EntityTypeBuilder<TEntity> builder);
}


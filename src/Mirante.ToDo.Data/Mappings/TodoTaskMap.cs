using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mirante.ToDo.Core.Entity;

namespace Mirante.ToDo.Data.Mappings
{
    public class TodoTaskMap : IEntityTypeConfiguration<ToDoTask>
    {
        public void Configure(EntityTypeBuilder<ToDoTask> builder)
        {
            builder.ToTable("ToDoTask", "dbo");

            builder.HasKey(e => e.Id)
                   .HasName("Id");

            builder.Property(x => x.Id)
                   .HasColumnName("Id")
                   .IsRequired(true);

            builder.Property(x => x.Titulo)
                   .HasColumnName("Titulo")
                   .IsRequired(true);

            builder.Property(x => x.Descricao)
                   .HasColumnName("Descricao")
                   .IsRequired(true);

            builder.Property(x => x.Status)
                   .HasColumnName("Status")
                   .IsRequired(true);

            builder.Property(x => x.DataVencimento)
                   .HasColumnName("DtVencimento")
                   .IsRequired(false);

            builder.Property(x => x.DataInclusao)
                   .HasColumnName("DtInclusao")
                   .IsRequired(true);

        }
    }
}

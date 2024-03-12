using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevsFrella.Infrastructure.Configurations
{
    public class TaskConfigurations : IEntityTypeConfiguration<ToDoList.Entities.Task>
    {
        public void Configure(EntityTypeBuilder<ToDoList.Entities.Task> builder)
        {
            builder
                .HasKey(p => p.Id);
        }
    }
}

using DataAnnotations;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    public class CourseConfiguration : EntityTypeConfiguration<Course> 
    {
        public CourseConfiguration()
        {
            
                        Property(c => c.Name)
                        .IsRequired()
                        .HasMaxLength(255);

            
                       Property(c => c.Description)
                       .IsRequired()
                       .HasMaxLength(2000);

            
                       HasRequired(a => a.Author)
                       .WithMany(c => c.Courses)
                       .HasForeignKey(a => a.AuthorId)
                       .WillCascadeOnDelete(false);

            
                        HasMany(c => c.Tags)
                        .WithMany(t => t.Courses)
                        .Map(m => m.ToTable("CourseTags"));

            
                        HasRequired(c => c.Cover)
                        .WithRequiredPrincipal(c => c.Course);
        }
    }
}

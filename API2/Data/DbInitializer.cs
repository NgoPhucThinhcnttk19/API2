using Microsoft.EntityFrameworkCore;
using API2.Models;
namespace API2.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;
        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }
        public void Seed()
        {
            _builder.Entity<Students>(a =>
            {
                a.HasData(new Students
                {
                    StudentId=new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                    Name="Ngô Phúc Thịnh ",
                });
                
            });
            _builder.Entity<Courses>(b =>
            {
                b.HasData(new Courses
                {
                    CoursesId = new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"),
                    CoursesName = "Web API______1",
                    Description = "Các ngành hot. 1 : làm giáo viên",
                });
               
            });
            _builder.Entity<StudentsCourses>(c =>
            {
                c.HasData(new StudentsCourses
                {
                    Id=1,
                    StudentId = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                    CoursesId = new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"),
                });
               
            });
        }
    }
}

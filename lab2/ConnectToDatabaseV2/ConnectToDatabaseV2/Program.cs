using Microsoft.EntityFrameworkCore;
using System;

namespace ConnectToDatabaseV2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StudentDbContext context = new StudentDbContext())
            {
                var group = new Group { GroupName = "30431" };
                var newstudent = new Student { Name = "Andrei", Group = group };
                context.Groups.Add(group);
                context.Students.Add(newstudent);

                context.SaveChanges();

                var students = context.Students.Include(x=> x.Group).ToListAsync().Result; // eager loading
                foreach (var student in students)
                {
                    Console.WriteLine("Student: " + student.Name + " Group " + student.Group?.GroupName ?? string.Empty);
                }

            }
            Console.WriteLine("Hello World!");
        }
    }
}

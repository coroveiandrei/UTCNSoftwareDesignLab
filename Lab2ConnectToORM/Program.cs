using Microsoft.EntityFrameworkCore;
using System;

namespace Lab2ConnectToORM
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StudentContext context = new StudentContext())
            {

                var newstudent = new Student { Name = "Mara", DateOfBirth = DateTime.Now };
                context.Students.Add(newstudent);
                context.SaveChanges();

                var students = context.Students.ToListAsync().Result;
                foreach(var student in students)
                {
                    Console.WriteLine("Student: " + student.Name);
                }
                
            }
            Console.WriteLine("Hello World!");
        }
    }
}

namespace _01.StudentSystem
{
    using _01.StudentSystem.Data;
    using _01.StudentSystem.Data.Enums;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //before start check stating class
            using (var db = new StudentSystemDbContext())
            {
                db.Database.Migrate();
                //To seed data use that method
                //InsertingDateInDb(db);
                //InsertingLicensesInDb(db);

                //Task N-1
                //PrintStudentsHomework(db);

                //Task N-2
                //PrintCourseNameAndResourses(db);

                //Task N-3
                //PrintCourseWithResourceCount(db);

                //Task N-4
                //PrintStudentsInCoursesInDefineDate(db);

                //Task N-5
                //PrintStudentsWithCoursesStuffs(db);

                //Task from License N-1
                //PrintResourcesNameWithLicence(db);

                //Task from License N-2
                //PrintStudentsWithCoursesHeIsEnrolled(db);

            }
        }

        private static void PrintStudentsWithCoursesHeIsEnrolled(StudentSystemDbContext db)
        {
            var result = db.Students
                .Select(s => new
                {
                    s.Name,
                    CoursesEnrolled = s.Coureses.Count,
                    TotalResourcesCount = s.Coureses.Sum(c => c.Coureses.Resources.Count()),
                    TotalLicensesCount = s.Coureses.Sum(c => c.Coureses.Resources.Select(r => r.Licenses).Count())
                })
                .OrderByDescending(s=>s.CoursesEnrolled)
                .ThenByDescending(s=>s.TotalResourcesCount)
                .ThenBy(s=>s.Name)
                .ToList();

            foreach (var student in result)
            {
                Console.WriteLine($"{student.Name}");
                Console.WriteLine($"Courses enrolled - {student.CoursesEnrolled}");
                Console.WriteLine($"Total resources - {student.TotalResourcesCount}");
                Console.WriteLine($"Total Licenses - {student.TotalLicensesCount}");
            }
        }

        private static void PrintResourcesNameWithLicence(StudentSystemDbContext db)
        {
            var result = db.Courses
                .OrderByDescending(c => c.Resources.Count)
                .ThenBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    ResourceName = c.Resources
                    .OrderByDescending(r => r.Licenses.Count)
                    .ThenBy(r => r.Name)
                    .Select(r => new
                    {
                        r.Name,
                        LicenseName = r.Licenses.Select(l => new
                        {
                            l.Name
                        })
                    })

                })
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine($"{course.Name}");
                foreach (var resource in course.ResourceName)
                {
                    Console.WriteLine($"{resource.Name}");
                    foreach (var license in resource.LicenseName)
                    {
                        Console.WriteLine($"{license.Name}");
                    }
                }
            }
        }

        private static void PrintStudentsWithCoursesStuffs(StudentSystemDbContext db)
        {
            var result = db.Students
                .Where(s => s.Coureses.Any())
                .Select(s => new
                {
                    s.Name,
                    CourseCount = s.Coureses.Count,
                    TotalPrice = s.Coureses.Sum(c => c.Coureses.Price),
                    AvaragePrice = s.Coureses.Average(c => c.Coureses.Price)
                })
                .OrderByDescending(s => s.TotalPrice)
                .ThenByDescending(s => s.CourseCount)
                .ThenBy(s => s.Name)
                .ToList();

            foreach (var student in result)
            {
                Console.WriteLine($"{student.Name}");
                Console.WriteLine($"Participate in {student.CourseCount}");
                Console.WriteLine($"Total price of courses {student.TotalPrice}");
                Console.WriteLine($"Avarage price of courses {student.AvaragePrice}");
            }
        }

        private static void PrintStudentsInCoursesInDefineDate(StudentSystemDbContext db)
        {
            var date = DateTime.Now.AddDays(26);
            var result = db.Courses
                .Where(c => c.StartDate < date && date < c.EndDate)
                .OrderByDescending(c => c.Students.Count)
                .ThenByDescending(c => c.EndDate.Subtract(c.StartDate))
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    CourseDuration = c.EndDate.Subtract(c.StartDate),
                    NumberOfStudents = c.Students.Count
                })
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine($"{course.Name}");
                Console.WriteLine($"-StartDate-{course.StartDate}");
                Console.WriteLine($"-EndDate-{course.EndDate}");
                Console.WriteLine($"-CouseDuration-{course.CourseDuration}");
                Console.WriteLine($"-StudentsEnrolled-{course.NumberOfStudents}");
            }
        }

        private static void PrintCourseWithResourceCount(StudentSystemDbContext db)
        {
            var result = db.Courses
                .Where(c => c.Resources.Count > 5)
                .OrderByDescending(c => c.Resources.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    Resource = c.Resources.Count
                })
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine($"-{course.Name}--{course.Resource}");
            }
        }

        private static void PrintCourseNameAndResourses(StudentSystemDbContext db)
        {
            var result = db.Courses
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    Resourses = c.Resources
                            .Select(r => new
                            {
                                r.Name,
                                r.Type,
                                r.Url
                            })
                })
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine($"{course.Name}--{course.Description}");

                foreach (var resouse in course.Resourses)
                {
                    Console.WriteLine($"{resouse.Name}--{resouse.Type}--{resouse.Url}");
                }
            }
        }

        private static void PrintStudentsHomework(StudentSystemDbContext db)
        {
            var result = db.Students
                .Select(s => new
                {
                    s.Name,
                    Homeworks = s.Homeworks
                    .Select(h => new
                    {
                        Content = h.Content,
                        Type = h.Type
                    })
                })
                .ToList();

            foreach (var student in result)
            {
                Console.WriteLine($"{student.Name}");
                foreach (var homework in student.Homeworks)
                {
                    Console.WriteLine($"--{homework.Content}-{homework.Type}");
                }
            }
        }

        private static void InsertingDateInDb(StudentSystemDbContext db)
        {
            Console.WriteLine("Adding data...");
            var currentDateTime = DateTime.Now;
            //Students
            for (int i = 1; i <= 25; i++)
            {
                db.Students.Add(new Students
                {
                    Name = $"Student {i}",
                    RegistrationDate = currentDateTime.AddDays(i),
                    BirthDay = currentDateTime.AddYears(-20).AddDays(i),
                    PhoneNumber = $"{i}{i}{i}"
                });
            }

            db.SaveChanges();

            //Courses
            List<Courses> courses = new List<Courses>();

            for (int i = 0; i < 25; i++)
            {
                var course = new Courses
                {
                    Name = $"Course N-{i}",
                    Description = $"Verry good {i}",
                    Price = 300 * i,
                    StartDate = currentDateTime.AddDays(i),
                    EndDate = currentDateTime.AddDays(5 + i)
                };
                courses.Add(course);
                db.Courses.Add(course);
            }

            db.SaveChanges();

            Random random = new Random();

            //Students in courses
            List<int> studentIds = db.Students
                .Select(s => s.Id)
                .ToList();

            for (int i = 1; i <= 25; i++)
            {
                int student = random.Next(2, 25 / 2);
                Courses currentCourse = courses[i - 1];

                for (int j = 1; j <= student; j++)
                {
                    int studentId = studentIds[random.Next(0, studentIds.Count)];
                    if (!currentCourse.Students.Any(s => s.StudentId == studentId))
                    {
                        currentCourse.Students.Add(new StudentCourse
                        {
                            StudentId = studentId
                        });
                    }
                    else
                    {
                        j--;
                    }
                }

                var resourses = random.Next(0, 20);
                var types = new[] { 0, 1, 2, 999 };

                for (int k = 0; k < 10; k++)
                {
                    currentCourse.Resources.Add(new Resources
                    {
                        Name = $"Resourse N-{i}",
                        Url = $"Url {i}",
                        Type = (ResourceType)types[random.Next(0, types.Length)]
                    });
                }
            }

            db.SaveChanges();

            //Homework
            for (int i = 0; i < 25; i++)
            {
                var currentCourse = courses[i];
                var studensIds = currentCourse.Students
                    .Select(s => s.StudentId)
                    .ToList();

                for (int j = 0; j < studensIds.Count; j++)
                {
                    var totalHomework = random.Next(2, 5);

                    for (int k = 0; k < totalHomework; k++)
                    {
                        db.Homework.Add(new Homework
                        {
                            Content = $"Content{i}",
                            SubmitionDate = currentDateTime.AddDays(i),
                            Type = ContentType.Zip,
                            StudentId = studensIds[j],
                            CoureseId = currentCourse.Id
                        });
                    }
                }
            }

            db.SaveChanges();

            Console.WriteLine("Data added!");
        }

        private static void InsertingLicensesInDb(StudentSystemDbContext db)
        {
            var random = new Random();
            var resorseId = db.Resources
                .Select(r => r.Id)
                .ToList();

            for (int i = 0; i < resorseId.Count; i++)
            {
                var totalLicense = random.Next(1, 4);

                for (int j = 0; j < totalLicense; j++)
                {
                    db.License.Add(new License
                    {
                        Name = $"License {j} {i}",
                        ResourceId = resorseId[i]
                    });
                }

                db.SaveChanges();
            }
        }
    }
}
using SweeftT7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using (var context = new SchoolDbContext())
{
    // Insert some data
    InsertSampleData(context);

    // select teachers who teaches any student named giorgi and display names
    var selectedTeachers = SelectTeachers("Giorgi", context);
    foreach (var teacher in selectedTeachers)
    {
        Console.WriteLine($"Teacher: {teacher.Name} {teacher.SurName}");
    }
    Console.ReadLine();
}
//}
static void InsertSampleData(SchoolDbContext context)
{
    // insert teachers
    var teacher1 = new Teacher { Name = "Tamar", SurName = "Chkhaidze", Gender = "Female", Subject = "Chemistry" };
    var teacher2 = new Teacher { Name = "Tsitsana", SurName = "Mgaloblishvili", Gender = "Female", Subject = "Science" };
    var teacher3 = new Teacher { Name = "David", SurName = "Natroshvili", Gender = "Male", Subject = "Math" };

    context.Teachers.AddRange(new List<Teacher> { teacher1, teacher2, teacher3 });
    context.SaveChanges();

    // insert pupils
    var pupil1 = new Pupil { Name = "Giorgi", SurName = "Gotsiridze", Gender = "Male", Class = "7th A class" };
    var pupil2 = new Pupil { Name = "Mariam", SurName = "Abuladze", Gender = "Female", Class = "11th B class" };
    var pupil3 = new Pupil { Name = "Giorgi", SurName = "Salukvadze", Gender = "Male", Class = "9th B Class" };

    context.Pupils.AddRange(new List<Pupil> { pupil1, pupil2, pupil3 });
    context.SaveChanges();

    // insert teacher-pupil
    var tp1 = new TeacherPupil { TId = 1, PId = 3 };  // Tamar - Giorgi (using ID from SQL data)
    var tp2 = new TeacherPupil { TId = 3, PId = 2 };  // David - Mariam (using ID from SQL data)
    var tp3 = new TeacherPupil { TId = 1, PId = 2 };  // Tamar - Mariam (using ID from SQL data)
    var tp4 = new TeacherPupil { TId = 3, PId = 1 };  // David - Giorgi (using ID from SQL data)
    var tp5 = new TeacherPupil { TId = 2, PId = 2 };  // Tsitsana - Mariam (using ID from SQL data)

    context.TeacherPupils.AddRange(new List<TeacherPupil> { tp1, tp2, tp3, tp4, tp5 });
    context.SaveChanges();

}

static IEnumerable<Teacher> SelectTeachers(string pupilName, SchoolDbContext context)
{
    //same way as in task6 but this time using linq
    return context.Teachers
      .Join(
            context.TeacherPupils,
            t => t.TId,
            tp => tp.TId,
            (t, tp) => new { Teacher = t, TeacherPupil = tp }
       )
      .Join(
            context.Pupils,
            tp => tp.TeacherPupil.PId,
            p => p.PId,
            (tp, p) => new { Teacher = tp.Teacher, Pupil = p }
      )
    .Where(tp => tp.Pupil.Name == "Giorgi")
    .Select(tp => tp.Teacher)
    .Distinct()
    .ToList();

}
// }
//}

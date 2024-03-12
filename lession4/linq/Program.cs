namespace Linq
{
    internal class Program
    {
        private static List<Student> _studentList = [];
        private static List<Education> _educationList = [];

        private struct Student
        {
            public int StudentID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public int EducationID { get; set; }
        }

        private struct Education
        {
            public int EducationID { get; set; }
            public string Name { get; set; }
        }

        private static void Main()
        {
            InitialList();

            Console.WriteLine("Aufgabe 1");
            Console.WriteLine("----------");
            //TODO Alle Studenten, die Wirtschaft studieren und über 18 Jahre alt sind. (Benützen Sie Extension Methods)
            Console.WriteLine(
                "Alle Studenten, die Wirtschaft studieren und über 18 Jahre alt sind:"
            );
            IEnumerable<string> students = _studentList
                .Where(s => s.EducationID == 1 && s.Age > 18)
                .Select(s => s.Name);
            students.ToList().ForEach(Console.WriteLine);
            Console.WriteLine("----------");

            Console.WriteLine("Aufgabe 2");
            Console.WriteLine("----------");
            //TODO Alle Studenten, die unter 20 Jahre alt sind. (Benützen Sie Linq und übergeben Sie das Resultat auf ein anonymes Attribut).
            Console.WriteLine("Alle Studenten, die unter 20 Jahre alt sind:");
            var studentsUnder20 = from s in _studentList where s.Age < 20 select new { s.Name };
            studentsUnder20.ToList().ForEach(s => Console.WriteLine(s.Name));
            Console.WriteLine("----------");

            Console.WriteLine("Aufgabe 3");
            Console.WriteLine("----------");
            //TODO Gruppieren Sie die Studentnamen unter dem Studienfach auf. (Benützen Sie Linq-Abfrage)
            Console.WriteLine("Gruppieren Sie die Studentnamen unter dem Studienfach auf:");
            var studentsByEducation =
                from s in _studentList
                join e in _educationList on s.EducationID equals e.EducationID
                group s by e.Name into g
                select new { Education = g.Key, Students = g.Select(s => s.Name) };
            studentsByEducation
                .ToList()
                .ForEach(e =>
                {
                    Console.WriteLine(e.Education);
                    e.Students.ToList().ForEach(s => Console.WriteLine(s));
                });

            Console.WriteLine("----------");

            Console.WriteLine("Aufgabe 4");
            Console.WriteLine("----------");
            //TODO Gruppieren Sie die Studentnamen unter dem Studienfach auf. (Benützen Sie Linq-Abfrage)
            Console.WriteLine("Gruppieren Sie die Studentnamen unter dem Studienfach auf:");
            var studentsByEducation2 = _studentList
                .Join(
                    _educationList,
                    s => s.EducationID,
                    e => e.EducationID,
                    (s, e) => new { s, e }
                )
                .GroupBy(x => x.e.Name, x => x.s.Name)
                .Select(g => new { Education = g.Key, Students = g });
            foreach (var education in studentsByEducation2)
            {
                Console.WriteLine(education.Education);
                foreach (string? student in education.Students)
                {
                    Console.WriteLine(student);
                }
            }
            Console.WriteLine("----------");

            Console.WriteLine("Aufgabe 5");
            Console.WriteLine("----------");
            //TODO Gruppieren Sie die Studentnamen unter dem Studienfach auf, die älter als 20 Jahre sind. (Benützen Sie Linq-Abfrage)
            Console.WriteLine(
                "Gruppieren Sie die Studentnamen unter dem Studienfach auf, die älter als 20 Jahre sind:"
            );
            var studentsByEducationOlder20 = _studentList
                .Join(
                    _educationList,
                    s => s.EducationID,
                    e => e.EducationID,
                    (s, e) => new { s, e }
                )
                .Where(x => x.s.Age > 20)
                .GroupBy(x => x.e.Name, x => x.s.Name)
                .Select(g => new { Education = g.Key, Students = g });
            foreach (var education in studentsByEducationOlder20)
            {
                Console.WriteLine(education.Education);
                foreach (string? student in education.Students)
                {
                    Console.WriteLine(student);
                }
            }
        }

        private static void InitialList()
        {
            _studentList =
            [
                new()
                {
                    StudentID = 1,
                    Name = "John",
                    Age = 18,
                    EducationID = 1
                },
                new()
                {
                    StudentID = 2,
                    Name = "Steve",
                    Age = 21,
                    EducationID = 1
                },
                new()
                {
                    StudentID = 3,
                    Name = "Bill",
                    Age = 18,
                    EducationID = 2
                },
                new()
                {
                    StudentID = 4,
                    Name = "Ram",
                    Age = 20,
                    EducationID = 2
                },
                new()
                {
                    StudentID = 5,
                    Name = "Ron",
                    Age = 21,
                    EducationID = 3
                }
            ];

            _educationList =
            [
                new() { EducationID = 1, Name = "Wirtschaft" },
                new() { EducationID = 2, Name = "Medizin" },
                new() { EducationID = 3, Name = "Informatik" }
            ];
        }
    }
}

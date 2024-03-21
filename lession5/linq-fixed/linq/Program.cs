using linq.Model;

namespace linq;

class Program
    {
        static void Main(string[] args)
        {
            var repo = new Repository();

            var abteilungListe = repo.GetAbteilungList();
            var mitarbeiterList = repo.GetMitarbeiterList();
            var projektListe = repo.GetProjekctList();

            Console.WriteLine("Aufgabe 1");
            Console.WriteLine("Eine Zeile --------------");
            mitarbeiterList.ForEach(x => Console.WriteLine($"{x.Name}, {x.Vorname}"));
            //TODO

            Console.WriteLine("--------------");


            Console.WriteLine("Aufgabe 2");
            Console.WriteLine("--------------");
            
            // Get all employees with first and last name, also join the department name using linq
            mitarbeiterList.Join(abteilungListe, a => a.AbteilungId, b => b.AbteilungId, (a, b) => new { a, b }).ToList().ForEach(x => Console.WriteLine($"{x.a.Name}, {x.a.Vorname}, {x.b.Name}")); 
            //TODO

            Console.WriteLine("--------------");


            Console.WriteLine("Aufgabe 3");
            Console.WriteLine("--------------");
            // Get all employees with first and last name, join the depratement also join the project name using linq
mitarbeiterList.Join(abteilungListe, a => a.AbteilungId, b => b.AbteilungId, (a, b) => new { a, b }).Join(projektListe, c => c.a.ProjektId, d => d.ProjekteId, (c, d) => new { c, d }).ToList().ForEach(x => Console.WriteLine($"{x.c.a.Name}, {x.c.a.Vorname}, {x.c.b.Name}, {x.d.ProjektName}")); 
            Console.WriteLine("--------------");

            Console.WriteLine("Aufgabe 4");
            Console.WriteLine("--------------");
            // Get all employees with first and last name, also join the department name where the department name is "Mechanik" using linq
            //TODO
            mitarbeiterList.Join(abteilungListe, a => a.AbteilungId, b => b.AbteilungId, (a, b) => new { a, b }).Where(x => x.b.Name == "Mechanik").ToList().ForEach(x => Console.WriteLine($"{x.a.Name}, {x.a.Vorname}, {x.b.Name}"));



            Console.WriteLine("--------------");

            Console.WriteLine("Aufgabe 5");
            Console.WriteLine("--------------");

        
            // Get all employees with first and last name, who are working on a project where the project name is "Mars" using linq

            //TODO
            mitarbeiterList.Join(projektListe, a => a.ProjektId, b => b.ProjekteId, (a, b) => new { a, b }).Where(x => x.b.ProjektName == "Mars").ToList().ForEach(x => Console.WriteLine($"{x.a.Name}, {x.a.Vorname}, {x.b.ProjektName}"));


            Console.WriteLine("--------------");


            Console.WriteLine("Aufgabe 6");
            Console.WriteLine("--------------");
            // Get all employees with first and last name, who are working on a project where the project name is "Erde" and the department name is "Software" using linq
            Console.WriteLine("Eine Zeile--------------");
            mitarbeiterList.Join(abteilungListe, a => a.AbteilungId, b => b.AbteilungId, (a, b) => new { a, b }).Join(projektListe, c => c.a.ProjektId, d => d.ProjekteId, (c, d) => new { c, d }).Where(x => x.d.ProjektName == "Erde" && x.c.b.Name == "Software").ToList().ForEach(x => Console.WriteLine($"{x.c.a.Name}, {x.c.a.Vorname}, {x.c.b.Name}, {x.d.ProjektName}"));  
            

            //TODO

            Console.WriteLine("--------------");

            Console.WriteLine("Aufgabe 7");
            Console.WriteLine("Eine Zeile --------------");

            //Get all employees with first and last name, where the first name starts with "K" using like % linq
            mitarbeiterList.Where(x => x.Name.StartsWith("K")).ToList().ForEach(x => Console.WriteLine($"{x.Name}, {x.Vorname}")); 

            Console.WriteLine("--------------");

            Console.WriteLine("Aufgabe 8");
            Console.WriteLine("Eine Zeile --------------");
            
            // Get the count of all employees, that are a team leader using linq
            Console.WriteLine(mitarbeiterList.Where(x => x.Position == "Abteilungsleiter").Count());
            

            Console.WriteLine("--------------");

            Console.WriteLine("Aufgabe 9");
            Console.WriteLine("Eine Zeile --------------");

            // Get the count of all employees, that are working on a project where the project name is "Mars" using linq
            Console.WriteLine(mitarbeiterList.Join(projektListe, a => a.ProjektId, b => b.ProjekteId, (a, b) => new { a, b }).Where(x => x.b.ProjektName == "Mars").Count());

            Console.WriteLine("--------------");

            Console.WriteLine("Aufgabe 10");
            Console.WriteLine("--------------");

            Console.WriteLine("nur wenn Aufgabe 10 erreicht ist, dann auskommentieren");

            //Add a new employee to the database
            var newMit = new Mitarbeiter
            {
                Name = "Schmid",
                Vorname = "Marco",
                Position = "Software",
                ProjektId = projektListe.Where(x => x.ProjektName == "Mars").FirstOrDefault().ProjekteId,
                AbteilungId = abteilungListe.Where(x => x.Name == "Software").FirstOrDefault().AbteilungId
            };
            repo.AddMitarbeiter(newMit);

            Console.WriteLine("--------------");

            Console.WriteLine("Aufgabe 11");
            Console.WriteLine("Eine Zeile --------------");

            //Count of all employees, that are working on a project where the project name is "Mars" and the departement is Software using linq
            Console.WriteLine(mitarbeiterList.Join(abteilungListe, a => a.AbteilungId, b => b.AbteilungId, (a, b) => new { a, b }).Join(projektListe, c => c.a.ProjektId, d => d.ProjekteId, (c, d) => new { c, d }).Where(x => x.d.ProjektName == "Mars" && x.c.b.Name == "Software").Count()); 
            Console.WriteLine("--------------");


            Console.WriteLine("Aufgabe 12");
            Console.WriteLine("Eine Zeile --------------");
            // Get the count of employies per department using linq
            abteilungListe.Join(mitarbeiterList, a => a.AbteilungId, b => b.AbteilungId, (a, b) => new { a, b }).GroupBy(x => x.a.Name).Select(x => new { Name = x.Key, Count = x.Count() }).ToList().ForEach(x => Console.WriteLine($"{x.Name}, {x.Count}"));

            //TODO

            Console.WriteLine("--------------");

            Console.WriteLine("Aufgabe 13");
            Console.WriteLine("Auslassen --------------");

           

            Console.WriteLine("--------------");

            Console.WriteLine("Aufgabe 14");
            // Count the projects where more than 1 employee is working on using linq(having, count)
            Console.WriteLine(mitarbeiterList.GroupBy(x => x.ProjektId).Where(x => x.Count() > 1).Count());
            

            Console.WriteLine("--------------");
            Console.ReadKey();
        }

    }
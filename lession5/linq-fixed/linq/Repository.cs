using linq.Model;

namespace linq;

public class Repository
{

        private JuveTestContext _context;

        public Repository()
        {
            _context = new JuveTestContext();
        }
        public List<Mitarbeiter> GetMitarbeiterList()
        {
            return _context.Mitarbeiters.ToList();
        }

        public void AddMitarbeiter(Mitarbeiter mit)
        {
            _context.Mitarbeiters.Add(mit);
            _context.SaveChanges();
        }

        public List<Abteilung> GetAbteilungList()
        {
            return _context.Abteilungs.ToList();
        }
       
        public List<Projekte> GetProjekctList()
        {
            return _context.Projektes.ToList();
        }
}
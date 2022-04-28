using Repo.Models;

namespace Repo.Repositorio.IRepository
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly BDReportesContext _personaRepository;
        public PersonaRepository(BDReportesContext personaRepository)
        {
            _personaRepository = personaRepository;
        }
        public bool ActualizarPersona(Persona persona)
        {
          _personaRepository.Personas.Update(persona);

            return Guardar();
        }

        public bool BorrarPersona(Persona persona)
        {
            _personaRepository.Personas.Remove(persona);

            return Guardar();
        }

        public bool CrearPersona(Persona persona)
        {
            _personaRepository.Personas.Add(persona);

            return Guardar();
        }

        public bool ExistePersona(string nombre)
        {
            bool valor = _personaRepository.Personas.Any(c=> c.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            return valor;

        }

        public bool ExistePersona(int id)
        {
            return _personaRepository.Personas.Any(c => c.Iidpersona == id);
                 }

        public ICollection<Persona> GesPersonas()
        {
            return _personaRepository.Personas.OrderBy(c => c.Nombre).ToList();

        }

        public Persona GetPersona(int id)
        {
            return _personaRepository.Personas.FirstOrDefault(c => c.Iidpersona == id);
        }

        public bool Guardar()
        {
            return _personaRepository.SaveChanges() >=0?true:false;
        }
    }
}

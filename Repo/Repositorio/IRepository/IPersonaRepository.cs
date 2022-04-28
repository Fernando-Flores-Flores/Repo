using Repo.Models;

namespace Repo.Repositorio.IRepository
{
    public interface IPersonaRepository
    {
        ICollection<Persona> GesPersonas();

        Persona GetPersona(int id);
        bool ExistePersona(string Nombre);

        bool ExistePersona(int id);

        bool CrearPersona(Persona persona);

        bool ActualizarPersona(Persona persona);

        bool BorrarPersona(Persona persona);

        bool Guardar();




    }
}

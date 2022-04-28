using AutoMapper;
using Repo.Models;
using Repo.Models.Dtos;

namespace Repo.PersonasMapper
{
    public class RepoMapper:Profile
    {
        public RepoMapper()
        {
            CreateMap<Persona, PersonaDto>().ReverseMap();
        }
    }
}

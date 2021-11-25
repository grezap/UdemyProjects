using AutoMapper;
using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Server.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Person, Person>()
                .ForMember(dst => dst.Picture, src => src.Ignore())
                ;
            CreateMap<Movie, Movie>()
                .ForMember(dst => dst.Poster, src => src.Ignore())
                ;
        }
    }
}

using AutoMapper;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            // Mapper.CreateMap<MemberShipTypeDto, MemberShipType>();

            Mapper.CreateMap<MemberShipType, MemberShipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            //Mapper.CreateMap<GenreDto, Genre>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
        }
    }
}
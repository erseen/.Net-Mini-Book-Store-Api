using AutoMapper;
using Data.Dto;
using Data.Entities;

namespace Api.Utilities.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<CreateBookDto, Book>().ReverseMap();
            CreateMap<CreateBookDto,BookDto>().ReverseMap();
            CreateMap<UpdateBookDto, Book>(); 

        }

    }
}

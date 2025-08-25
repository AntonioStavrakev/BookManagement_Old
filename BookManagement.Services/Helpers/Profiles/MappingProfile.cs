using AutoMapper;
using BookManagement.Core.DTOs.BookDTOs;
using BookManagement.Core.DTOs.PublisherDTOs;
using BookManagement.Core.Models;
using BookManagement.Services.Models.AuthorModels.DTOs;

namespace BookManagement.Services.Helpers.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Author, AuthorGeneralDTO>().ReverseMap();
        CreateMap<Author, AuthorPropertiesDTO>().ReverseMap();
        
        CreateMap<Publisher, PublisherGeneralDTO>().ReverseMap();
        CreateMap<Publisher, PublisherPropertiesDTO>().ReverseMap();
        
        CreateMap<Book, BookGeneralDTO>().ReverseMap();
        CreateMap<Book, BookPropertiesDTO>().ReverseMap();
    }
    
}
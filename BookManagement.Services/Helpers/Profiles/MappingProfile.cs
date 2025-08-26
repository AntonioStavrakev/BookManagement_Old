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
        
        
        CreateMap<Book, BookGeneralDTO>()
            .ForMember(d => d.AuthorIDs,
                opt => opt.MapFrom(s => s.BookAuthorList.Select(ba => ba.AuthorId)));
        CreateMap<BookGeneralDTO, Book>()
            .ForMember(d => d.BookAuthorList, opt => opt.Ignore());
        CreateMap<Book, BookPropertiesDTO>().ReverseMap();
    }
    
}
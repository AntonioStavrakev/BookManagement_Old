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
        
        
        // BOOK MAPPINGS:
        // Book -> BookGeneralDTO (read)
        CreateMap<Book, BookGeneralDTO>()
            .ForMember(d => d.AuthorIDs,
                opt => opt.MapFrom(s => s.BookAuthorList.Select(ba => ba.AuthorId)));

        // BookGeneralDTO -> Book (write/update) - populate BookAuthorList from AuthorIDs
        CreateMap<BookGeneralDTO, Book>()
            .ForMember(d => d.BookAuthorList,
                opt => opt.MapFrom(s => s.AuthorIDs == null
                    ? new List<BookAuthor>()
                    : s.AuthorIDs.Select(id => new BookAuthor { AuthorId = id }).ToList()));

        // BookPropertiesDTO -> Book (create) - populate BookAuthorList from AuthorIDs
        CreateMap<BookPropertiesDTO, Book>()
            .ForMember(d => d.BookAuthorList,
                opt => opt.MapFrom(s => s.AuthorIDs == null
                    ? new List<BookAuthor>()
                    : s.AuthorIDs.Select(id => new BookAuthor { AuthorId = id }).ToList()));

        // Book -> BookPropertiesDTO (read)
        CreateMap<Book, BookPropertiesDTO>()
            .ForMember(d => d.AuthorIDs,
                opt => opt.MapFrom(s => s.BookAuthorList.Select(ba => ba.AuthorId)));
    
    }
    
}
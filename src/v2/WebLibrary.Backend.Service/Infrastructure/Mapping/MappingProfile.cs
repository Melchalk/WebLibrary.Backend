using AutoMapper;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Book;
using WebLibrary.Backend.Models.DTO.Requests.Hall;
using WebLibrary.Backend.Models.DTO.Requests.Issue;
using WebLibrary.Backend.Models.DTO.Requests.Librarian;
using WebLibrary.Backend.Models.DTO.Requests.Library;
using WebLibrary.Backend.Models.DTO.Requests.Reader;
using WebLibrary.Backend.Models.DTO.Responses.Book;
using WebLibrary.Backend.Models.DTO.Responses.Hall;
using WebLibrary.Backend.Models.DTO.Responses.Issue;
using WebLibrary.Backend.Models.DTO.Responses.Librarian;
using WebLibrary.Backend.Models.DTO.Responses.Library;
using WebLibrary.Backend.Models.DTO.Responses.Reader;

namespace WebLibrary.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DbBook, GetBookResponse>();
        CreateMap<CreateBookRequest, DbBook>()
            .ForMember(db => db.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

        CreateMap<DbReader, GetReaderResponse>()
            .ForMember(response => response.IssueId, opt => opt.MapFrom<Guid?>(db => db.Issue != null ? db.Issue!.Id : null));
        CreateMap<CreateReaderRequest, DbReader>()
            .ForMember(db => db.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

        CreateMap<DbLibrary, GetLibraryResponse>()
            .ForMember(response => response.LibrariansCount, opt => opt.MapFrom(db => db.Librarians.Count))
            .ForMember(response => response.BooksCount, opt => opt.MapFrom(db => db.Books.Count))
            .ForMember(response => response.IssuesCount, opt => opt.MapFrom(db => db.Books.Count(b => b.IssueId != null)));
        CreateMap<CreateLibraryRequest, DbLibrary>();

        CreateMap<DbLibrarian, GetLibrarianResponse>();
        CreateMap<CreateLibrarianRequest, DbLibrarian>()
            .ForMember(db => db.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

        CreateMap<DbHall, GetHallResponse>();
        CreateMap<CreateHallRequest, DbHall>();

        CreateMap<DbIssue, GetIssueResponse>()
            .ForMember(response => response.ReturnDate, opt => opt.MapFrom(db => db.Books.Select(b => b.Id)));
        CreateMap<CreateIssueRequest, DbIssue>()
            .ForMember(db => db.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
    }
}

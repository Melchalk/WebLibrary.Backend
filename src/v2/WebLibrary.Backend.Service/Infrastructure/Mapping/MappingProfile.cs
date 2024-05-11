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
        CreateMap<CreateBookRequest, DbBook>();

        CreateMap<DbReader, GetReaderResponse>();
        CreateMap<CreateReaderRequest, DbReader>();

        CreateMap<DbLibrary, GetLibraryResponse>();
        CreateMap<CreateLibraryRequest, DbLibrary>();

        CreateMap<DbLibrarian, GetLibrarianResponse>();
        CreateMap<CreateLibrarianRequest, DbLibrarian>();

        CreateMap<DbHall, GetHallResponse>();
        CreateMap<CreateHallRequest, DbHall>();

        CreateMap<DbIssue, GetIssueResponse>();
        CreateMap<CreateIssueRequest, DbIssue>();
    }
}

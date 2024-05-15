using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Librarian;
using WebLibrary.Backend.Models.DTO.Responses.Librarian;

namespace WebLibrary.Backend.Auth.Services.Interfaces;

public interface IUserService
{
    Task<DbLibrarian> RegisterUser(CreateLibrarianRequest request, CancellationToken token);

    Task<DbLibrarian> GetUserByPhone(string phone, CancellationToken token);

    Task<GetLibrarianResponse> GetCurrentUser(CancellationToken token);

    Task DeleteCurrentUser(CancellationToken token);
}

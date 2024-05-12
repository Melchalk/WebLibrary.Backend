using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Librarian;

namespace WebLibrary.Backend.Auth.Services.Interfaces;

public interface IUserService
{
    Task<DbLibrarian> RegisterUser(CreateLibrarianRequest request, CancellationToken token);

    Task<DbLibrarian> GetUserByPhone(string phone, CancellationToken token);
}

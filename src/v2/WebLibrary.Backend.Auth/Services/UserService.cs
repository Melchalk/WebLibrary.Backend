using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text;
using WebLibrary.Backend.Auth.Helpers;
using WebLibrary.Backend.Auth.Services.Interfaces;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Librarian;
using WebLibrary.Backend.Models.DTO.Responses.Librarian;
using WebLibrary.Backend.Repositories.Interfaces;
using WebLibrary.Backend.Extensions;

namespace WebLibrary.Backend.Auth.Services;

public class UserService : IUserService
{
    private const string START_PHONE = "+7";

    private readonly IHttpContextAccessor _httpContext;

    private readonly ILibrarianRepository _repository;
    private readonly IMapper _mapper;

    public UserService(
        IHttpContextAccessor httpContext,
        ILibrarianRepository repository,
        IMapper mapper)
    {
        _httpContext = httpContext;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DbLibrarian> RegisterUser(
        CreateLibrarianRequest request, CancellationToken token)
    {
        StringBuilder phone = new(START_PHONE);

        request.Phone = request.Phone.StartsWith(START_PHONE)
            ? request.Phone[START_PHONE.Length..]
            : request.Phone[(START_PHONE.Length - 1)..];

        foreach (var symbol in request.Phone)
        {
            if (char.IsDigit(symbol))
            {
                phone.Append(symbol);
            }
        }

        var phoneChecked = phone.ToString();

        if (await _repository.Get()
            .AnyAsync(x => string.Equals(x.Phone, phoneChecked), token))
        {
            throw new ArgumentException("User with this phone already exists.");
        }

        request.Phone = phoneChecked;

        string salt = $"{Guid.NewGuid()}{Guid.NewGuid()}";

        var dbUser = _mapper.Map<DbLibrarian>(request);

        dbUser.Salt = salt;
        dbUser.Password = PasswordHelper.GetPasswordHash(dbUser.Phone, dbUser.Password, salt);

        await _repository.AddAsync(dbUser, token);

        return dbUser;
    }

    public async Task<DbLibrarian> GetUserByPhone(string phone, CancellationToken token)
    {
        var user = await _repository.Get()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Phone == phone, token)
            ?? throw new ArgumentException($"User with phone {phone} is not found.");

        return user;
    }

    public async Task<GetLibrarianResponse> GetCurrentUser(CancellationToken token)
    {
        var phone = _httpContext.GetUserPhone();

        var user = await _repository.Get()
            .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Phone == phone, token)
        ?? throw new ArgumentException($"User with phone {phone} is not found.");

        return _mapper.Map<GetLibrarianResponse>(user);
    }

    public async Task DeleteCurrentUser(CancellationToken token)
    {
        var phone = _httpContext.GetUserPhone();

        var user = await _repository.Get()
            .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Phone == phone, token)
        ?? throw new ArgumentException($"User with phone {phone} is not found.");

        await _repository.DeleteAsync(user, token);
    }
}

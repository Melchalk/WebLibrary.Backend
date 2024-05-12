using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text;
using WebLibrary.Backend.Auth.Helpers;
using WebLibrary.Backend.Auth.Services.Interfaces;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Librarian;
using WebLibrary.Backend.Repositories.Interfaces;

namespace WebLibrary.Backend.Auth.Services;

public class UserService : IUserService
{
    private const string START_PHONE = "+7";

    private readonly ILibrarianRepository _repository;
    private readonly IMapper _mapper;

    public UserService(
        ILibrarianRepository repository,
        IMapper mapper)
    {
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

        await _repository.AddAsync(dbUser);

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
}

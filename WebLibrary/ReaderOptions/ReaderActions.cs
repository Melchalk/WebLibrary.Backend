using DbModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Provider.Repositories;
using WebLibrary.Mappers;
using WebLibrary.ModelRequest;
using WebLibrary.Validators;

namespace WebLibrary.ReaderOptions;

public class ReaderActions : IReaderActions
{
    private const string NOT_FOUND = "ID is not found";
    private const string DELETE = "The deletion was successful";

    private readonly IReaderRepository _readerRepository;

    private readonly ICreateReaderRequestValidator _validator;
    private readonly IReaderMapper _mapper;

    public ReaderActions(
        IReaderRepository readerRepository,
        ICreateReaderRequestValidator validator,
        IReaderMapper mapper)
    {
        _readerRepository = readerRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public IActionResult Create(ReaderRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            List<string> errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return new BadRequestObjectResult(errors);
        }
        else
        {
            DbReader reader = _mapper.Map(request);

            _readerRepository.Add(reader);

            return new OkObjectResult(reader.Id);
        }
    }

    public IActionResult Get()
    {
        List<DbReader> dbReaders = _readerRepository.Get().ToList();

        List<ReaderRequest> readerRequests = new();

        foreach (DbReader reader in dbReaders)
        {
            readerRequests.Add(_mapper.Map(reader));
        }

        return new OkObjectResult(readerRequests);
    }

    public IActionResult Get(Guid id)
    {
        DbReader? reader = _readerRepository.Get(id);

        if (reader is null)
        {
            return new NotFoundObjectResult(NOT_FOUND);
        }
        else
        {
            return new OkObjectResult(_mapper.Map(reader));
        }
    }

    public IActionResult Update(Guid id, ReaderRequest request)
    {
        if (_readerRepository.Get(id) is null)
        {
            return new NotFoundObjectResult(NOT_FOUND);
        }
        else
        {
            ValidationResult result = _validator.Validate(request);

            if (!result.IsValid)
            {
                List<string> errors = result.Errors.Select(e => e.ErrorMessage).ToList();

                return new BadRequestObjectResult(errors);
            }
            else
            {
                DbReader reader = _mapper.Map(request);
                reader.Id = id;

                _readerRepository.Update(reader);

                return new OkResult();
            }
        }
    }

    public IActionResult Delete(Guid id)
    {
        DbReader? reader = _readerRepository.Get(id);

        if (reader is not null)
        {
            _readerRepository.Delete(reader);

            return new OkObjectResult(DELETE);
        }
        else
        {
            return new NotFoundObjectResult(NOT_FOUND);
        }
    }
}
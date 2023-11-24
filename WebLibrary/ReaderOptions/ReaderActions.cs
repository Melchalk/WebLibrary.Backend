using DbModels;
using FluentValidation.Results;
using Provider.Repositories;
using WebLibrary.Mappers;
using WebLibrary.ModelRequest;
using WebLibrary.ModelsResponses.ReaderResponses;
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

    public CreateReaderResponse Create(CreateReaderRequest request)
    {
        CreateReaderResponse createResponse = new();

        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            createResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        }
        else
        {
            DbReader reader = _mapper.Map(request);

            _readerRepository.Add(reader);

            createResponse.Id = reader.Id;
        }

        return createResponse;
    }

    public GetReaderResponse Get(Guid id)
    {
        GetReaderResponse getResponse = new();

        DbReader? reader = _readerRepository.Get(id);

        if (reader is null)
        {
            getResponse.Error = NOT_FOUND;
        }
        else
        {
            getResponse.ReaderRequest = _mapper.Map(reader);
        }

        return getResponse;
    }

    public UpdateReaderResponse Update(Guid id, CreateReaderRequest request)
    {
        UpdateReaderResponse updateResponse = new();

        if (_readerRepository.Get(id) is null)
        {
            updateResponse.Errors = new() { NOT_FOUND };
        }
        else
        {
            ValidationResult result = _validator.Validate(request);

            if (!result.IsValid)
            {
                updateResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                DbReader reader = _mapper.Map(request);
                reader.Id = id;

                _readerRepository.Update(reader);

                updateResponse.Result = true;
            }
        }

        return updateResponse;
    }

    public DeleteReaderResponse Delete(Guid id)
    {
        DeleteReaderResponse deleteResponse = new();

        DbReader? reader = _readerRepository.Get(id);

        if (reader is not null)
        {
            _readerRepository.Delete(reader);
            deleteResponse.Result = DELETE;
        }
        else
        {
            deleteResponse.Result = NOT_FOUND;
        }

        return deleteResponse;
    }
}
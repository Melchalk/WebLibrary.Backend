using LibraryStructure.Validators.Hall;
using Provider.Repositories.Hall;
using WebLibrary.Mappers.Hall;

namespace LibraryStructure.Commands.Hall.Commands;

public abstract class HallActions
{
    protected const string NOT_FOUND = "ID is not found";

    protected readonly IHallRepository _hallRepository;

    protected readonly ICreateHallRequestValidator _validator;
    protected readonly IHallMapper _mapper;

    public HallActions(
        IHallRepository hallRepository,
        ICreateHallRequestValidator validator,
        IHallMapper mapper)
    {
        _hallRepository = hallRepository;
        _validator = validator;
        _mapper = mapper;
    }
}
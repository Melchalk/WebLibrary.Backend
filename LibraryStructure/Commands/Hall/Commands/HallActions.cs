using LibraryStructure.Validators.Hall;
using Provider.Repositories.Hall;

namespace LibraryStructure.Commands.Hall.Commands;

public abstract class HallActions
{
    protected const string NOT_FOUND = "ID is not found";

    protected readonly IHallRepository _HallRepository;

    protected readonly ICreateHallRequestValidator _validator;
    protected readonly IHallMapper _mapper;

    public HallActions(
        IHallRepository HallRepository,
        ICreateHallRequestValidator validator,
        IHallMapper mapper)
    {
        _HallRepository = HallRepository;
        _validator = validator;
        _mapper = mapper;
    }
}
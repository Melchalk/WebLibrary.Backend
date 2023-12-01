using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;
using WebLibrary.Commands.Common_interfaces;

namespace LibraryStructure.Commands.Hall.Interfaces;

public interface ICreaterHall : ICreater<CreateHallRequest, CreateHallResponse>
{
}

using ServiceModels.Responses.Librarian;
using WebLibrary.Commands.Common_interfaces;
using ServiceModels.Requests.Librarian;

namespace LibraryStructure.Commands.Librarian.Interfaces;

public interface ICreaterLibrarian : ICreater<CreateLibrarianRequest, CreateLibrarianResponse>
{
}
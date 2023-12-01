using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;
using WebLibrary.Commands.Common_interfaces;

namespace LibraryStructure.Commands.Librarian.Interfaces;

public interface IUpdaterLibrarian : IUpdater<UpdateLibrarianRequest, UpdateLibrarianResponse>
{
}

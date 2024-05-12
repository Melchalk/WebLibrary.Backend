namespace WebLibrary.Backend.Provider.Interfaces;

public interface IBaseDataProvider
{
    Task SaveAsync(CancellationToken token);

    void Save();
}

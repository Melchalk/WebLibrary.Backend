namespace WebLibrary.Backend.Provider.Interfaces;

public interface IBaseDataProvider
{
    Task SaveAsync();

    void Save();
}

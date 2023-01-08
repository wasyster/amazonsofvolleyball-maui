namespace MauiUI.Storage;

public interface IStorageService
{
    Task<T> Get<T>(string key, T defaultValue);
    Task Save<T>(string key, T value);
}

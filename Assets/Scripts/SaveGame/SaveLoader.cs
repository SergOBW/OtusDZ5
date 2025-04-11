using UnityEngine;
using VContainer;

public interface ISaveLoader
{
    public void SaveGame(IObjectResolver objectResolver, IGameRepository gameRepository);

    public void LoadGame(IObjectResolver objectResolver, IGameRepository gameRepository);
}

public abstract class SaveLoader<TService, TData> : ISaveLoader
{
    public void SaveGame(IObjectResolver objectResolver, IGameRepository gameRepository)
    {
        var service = objectResolver.Resolve<TService>();

        var data = ConvertToData(service);
        gameRepository.SetData(data);
        
        Debug.Log($"Saved data {data.GetType().Name}");
    }

    public void LoadGame(IObjectResolver objectResolver, IGameRepository gameRepository)
    {
        var service = objectResolver.Resolve<TService>();


        if (gameRepository.TryGetData(out TData data))
        {
            SetupData(service, data);
            Debug.Log($"{data.GetType().Name} loaded");
        }
        else
        {
            SetupDefaultData(service, data);
            Debug.Log($"{data.GetType().Name} not loaded, setup default");
        }
        
        gameRepository.SetData(data);
        
        Debug.Log($"Load data {data.GetType().Name}");
    }

    protected abstract TData ConvertToData(TService service);
    protected abstract void SetupData(TService service, TData data);
    protected virtual void SetupDefaultData(TService service, TData data) { }
}

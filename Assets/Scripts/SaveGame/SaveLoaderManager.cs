using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

public class SaveLoaderManager : MonoBehaviour
{
    private List<ISaveLoader> _saveLoaders = new List<ISaveLoader>();
    private IGameRepository _gameRepository;
    private IObjectResolver _objectResolver;
    [Inject]
    public void Construct(IObjectResolver  objectResolver, IGameRepository gameRepository)
    {
        _objectResolver = objectResolver;
        var saveLoaders = _objectResolver.Resolve<IEnumerable<ISaveLoader>>();
        foreach (var loader in saveLoaders)
        {
            _saveLoaders.Add(loader);
        }
        _gameRepository = gameRepository;
    }

    [Button]
    public void Save()
    {
        foreach (var saveLoader in _saveLoaders)
        {
            saveLoader.SaveGame(_objectResolver,_gameRepository);
        }
        
        _gameRepository.SaveState();
    }
    
    [Button]
    public void Load()
    {
        _gameRepository.LoadState();
        foreach (var saveLoader in _saveLoaders)
        {
            saveLoader.LoadGame(_objectResolver,_gameRepository);
        }
    }
}
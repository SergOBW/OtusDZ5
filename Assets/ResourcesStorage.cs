using System.Collections.Generic;
using Homeworks.SaveLoad;
using UnityEngine;
using VContainer.Unity;

public class ResourceSave
{
    public string Name;
    public int RemainingCount;

    public void CreateSave(string name, int remainingCount)
    {
        Name = name;
        RemainingCount = remainingCount;
    }
}

public class ResourcesStorage : IInitializable
{
    private ResourceObject[] _resourceObjects;

    public void Initialize()
    {
        _resourceObjects = Object.FindObjectsOfType<ResourceObject>();
    }

    public void SetupResources(List<ResourceSave> resourceSaves)
    {
        foreach (var resourceObject in _resourceObjects)
        {
            foreach (var resourceSave in resourceSaves)
            {
                if (resourceObject.gameObject.name == resourceSave.Name)
                {
                    resourceObject.remainingCount = resourceSave.RemainingCount;
                    break;
                }
            }
        }
    }
    
    public List<ResourceSave> GetCurrentResources()
    {
        var resourceSaves = new List<ResourceSave>();

        foreach (var resource in _resourceObjects)
        {
            if (resource == null)
            {
                continue;
            }
            ResourceSave resourceSave = new ResourceSave();
            resourceSave.CreateSave(resource.gameObject.name, resource.remainingCount);
            resourceSaves.Add(resourceSave);
        }

        return resourceSaves;
    }
    
}

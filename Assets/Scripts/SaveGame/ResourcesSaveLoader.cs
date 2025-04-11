using System.Collections.Generic;

public class ResourcesSaveLoader : SaveLoader<ResourcesStorage, List<ResourceSave>>
{
    protected override List<ResourceSave> ConvertToData(ResourcesStorage service)
    {
        return service.GetCurrentResources();
    }

    protected override void SetupData(ResourcesStorage service, List<ResourceSave> data)
    {
        service.SetupResources(data);
    }
}
using System.Collections.Generic;
public class UnitPositionSaveLoader : SaveLoader<UnitPositionStorage,List<UnitPositionSave>>
{
    private UnitPositionStorage _unitPositionStorage;
    
    protected override List<UnitPositionSave> ConvertToData(UnitPositionStorage service)
    {
        return service.GetCurrentPositions();
    }

    protected override void SetupData(UnitPositionStorage service, List<UnitPositionSave> data)
    {
        service.SetupPositions(data);
    }
}

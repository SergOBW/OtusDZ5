using System.Collections.Generic;

public class UnitStatsSaveLoader : SaveLoader<UnitStatStorage, List<UnitStatSaves>>
{
    protected override List<UnitStatSaves> ConvertToData(UnitStatStorage service)
    {
        return service.GetCurrentStats();
    }

    protected override void SetupData(UnitStatStorage service, List<UnitStatSaves> data)
    {
        service.SetupStats(data);
    }
}
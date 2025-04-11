using System.Collections.Generic;
using Homeworks.SaveLoad;
using UnityEngine;
using IInitializable = VContainer.Unity.IInitializable;

public class UnitStatSaves
{
    public string Name;
    
    public int HitPoints;
    public int Speed;
    public int Damage;

    public void CreateSave(UnitObject unitObject)
    {
        Name = unitObject.name;
        
        HitPoints = unitObject.hitPoints;
        Speed = unitObject.speed;
        Damage = unitObject.damage;
    }
}

public class UnitStatStorage : IInitializable
{
    private List<UnitObject> _unitObject= new List<UnitObject>();
    
    public void Initialize()
    {
        UnitObject[] unitObjects = Object.FindObjectsOfType<UnitObject>();
        _unitObject = new List<UnitObject>(unitObjects);
        Debug.Log(_unitObject.Count);
    }
    
    public void SetupStats(List<UnitStatSaves> resourcesDictionary)
    {
        foreach (var unitObject in _unitObject)
        {
            foreach (var unitStatSave in resourcesDictionary)
            {
                if (unitObject.gameObject.name == unitStatSave.Name)
                {
                    unitObject.hitPoints = unitStatSave.HitPoints;
                    unitObject.speed = unitStatSave.Speed;
                    unitObject.damage = unitStatSave.Damage;
                    break;
                }
            }
        }
    }
    
    public List<UnitStatSaves> GetCurrentStats()
    {
        var unitStatSavesList = new List<UnitStatSaves>();

        foreach (var unitObject in _unitObject)
        {
            if (unitObject == null)
            {
                continue;
            }
            UnitStatSaves resourceSave = new UnitStatSaves();
            resourceSave.CreateSave(unitObject);
            unitStatSavesList.Add(resourceSave);
        }

        return unitStatSavesList;
    }
}
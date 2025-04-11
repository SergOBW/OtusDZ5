using System.Collections.Generic;
using Homeworks.SaveLoad;
using UnityEngine;
using VContainer.Unity;

public class UnitPositionSave
{
    public string UnitName;
    
    public float X;
    public float Y;
    public float Z;
    
    public void CreateSave(string unitName, Vector3 position)
    {
        UnitName = unitName;
        
        X = position.x;
        Y = position.y;
        Z = position.z;
    }

    public Vector3 GetVector3()
    {
        return new Vector3(X, Y, Z);
    }
}

public class UnitPositionStorage : IInitializable
{
    private UnitObject[] _units;
    
    public void Initialize()
    {
        _units = Object.FindObjectsOfType<UnitObject>();
    }
    
    public void SetupPositions(List<UnitPositionSave> unitSaveList)
    {
        foreach (var unit in _units)
        {
            foreach (var unitPositionSave in unitSaveList)
            {
                if (unitPositionSave.UnitName == unit.gameObject.name)
                {
                    unit.transform.position = unitPositionSave.GetVector3();
                    break;
                }
            }
        }
    }
    
    public List<UnitPositionSave> GetCurrentPositions()
    {
        var unitSaveList = new List<UnitPositionSave>();

        foreach (var unit in _units)
        {
            if (unit != null)
            {
                UnitPositionSave unitPositionSave = new UnitPositionSave();
                unitPositionSave.CreateSave(unit.gameObject.name, unit.transform.position);
                unitSaveList.Add(unitPositionSave);
            }
        }

        return unitSaveList;
    }
}
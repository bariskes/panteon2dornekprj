using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BuildingTypes
{
    Barracks,
    PowerPlants
}

public class BuildingFactory
{

    public IBuilding Building(BuildingTypes building)
    {
        switch (building)
        {
            case global::BuildingTypes.Barracks:
                return new Barracks();

            case global::BuildingTypes.PowerPlants:
                return new PowerPlants();
            default:
                return new PowerPlants();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingModel : MonoBehaviour {

    // Use this for initialization
    public BuildingView View;
    public bool CanSpawnItems;
    public Sprite Selected;
    public Sprite NotSelected;
    public Sprite SpawnUnitImage;
    public Sprite NoUnit;

    public void ResetValues()
    {
        CanSpawnItems = false;
        SpawnUnitImage = null;
        SpawnUnitImage = NoUnit;
        Selected = NotSelected;
        
       
    }
    public void UpdateValues(Sprite spawnUnitImage,bool canSpawnItems)
    {
        CanSpawnItems = canSpawnItems;
        SpawnUnitImage = spawnUnitImage;
    }
    //public void Setvalues(bool canspawnItems,Sprite spawnUnitImage)
    //{
    //    CanSpawnItems=canspawnItems;
    //    SpawnUnitImage = spawnUnitImage;
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour {

    public BuildingModel model;
    private void Start()
    {
        model.ResetValues();
    }
    public bool GetCanSpawnUnit()
    {
        return model.CanSpawnItems; 
    }
    public Sprite SetNoUnitSprite()
    {
        return model.NoUnit;
    }
    public Sprite GetBuildingSprite()
    {
        return model.Selected;
    }
    public Sprite GetSoliderSprite()
    {
        return model.SpawnUnitImage;
    }
    public void SetSoliderSprite(Sprite spr)
    {
        model.SpawnUnitImage = spr;
    }
    public void OnSoliderClicked(Sprite SoliderSprite)
    {
        model.UpdateValues(SoliderSprite, true);
    }
}

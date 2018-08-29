using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barracks: IBuilding
{



    //sets transform of building
    public void SetBuildingHud(Vector2 pos, GameObject bld)
    {
        bld.transform.position = pos;
    }



    // sets sprite of building abilities
    //
    public void SetBuildingModel(GameObject bld, GameObject selectedbuilt)
    {
        BuildingProperties bldbrk = bld.GetComponent<BuildingProperties>();
        bldbrk.Cubex = 3F;
        bldbrk.Cubey = 3F;
        bldbrk.BtnClick = bld.GetComponent<Button>();
        bldbrk.BuildingGmObj = selectedbuilt;
    }
}

   


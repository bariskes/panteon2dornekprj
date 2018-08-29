using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemCreate : MonoBehaviour
{

    // button count on barracks menu
    public int BarracksCount = 25;
    // button count on powerplant
    public int PowerSupplyCount = 25;
    // where will button appier and whichtransform is parent for barracks and power plants
    public Transform StartPosBarrack, BarracksParent;
    public Transform StartPosPowerPlant, PowerPlantParent;

    //barracks button and object when clicked
    public GameObject BarracksButton, BarracksCreated;
    //powerplant button and object when clicked
    public GameObject PowerPlantButton, PowerPlantCreated;
    /// <summary>
    /// buildings for building factory  pattern
    /// </summary>
    private List<IBuilding> buildings = new List<IBuilding>();
    private BuildingFactory buildingFactory = new BuildingFactory();
    void Start()
    {
        CreateMenuObjects(BarracksCount, BarracksButton, BarracksCreated, BarracksParent, StartPosBarrack, BuildingTypes.Barracks);
        CreateMenuObjects(PowerSupplyCount, PowerPlantButton, PowerPlantCreated, PowerPlantParent, StartPosPowerPlant, BuildingTypes.PowerPlants);

    }
    void CreateMenuObjects(int Count, GameObject buildingButton, GameObject selectedObject,
        Transform parentPos, Transform startPos, BuildingTypes type)
    {
        //start pos of building
        Vector2 pos = startPos.position;

        for (int i = 0; i < Count; i++)
        {
            pos = new Vector2(pos.x, pos.y - 1.5F);
            // adds current building type to factory
            buildings.Add(buildingFactory.Building(type));
            var q = buildings[buildings.Count - 1];
            // implements factory methots
            q.SetBuildingHud(pos, buildingButton);
            q.SetBuildingModel(buildingButton, selectedObject);
            // creates button
            GameObject gm = Instantiate(buildingButton, pos, Quaternion.identity);
            // sets the parent transform
            gm.transform.SetParent(parentPos, true);
            // local scale and rect transform is being set
            gm.GetComponent<RectTransform>().position = pos;
            gm.transform.localScale = new Vector3(1, 1, 1);
        }

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingProperties : MonoBehaviour
{

    public float Cubex;
    public float Cubey;
    public Button BtnClick;
    public GameObject BuildingGmObj;
    private void Start()
    {
        BtnClick.onClick.RemoveAllListeners();
        BtnClick.onClick.AddListener(() => createBuildingTemplate());
    }
    // Use this for initialization

    private void createBuildingTemplate()
    {
        GameObject g = (GameObject)Instantiate(BuildingGmObj, transform.position, Quaternion.identity);
        TemplateScript temps = g.GetComponent<TemplateScript>();
        // crates visibility
        temps.Cubex = Cubex;
        temps.Cubey = Cubey;
        temps.isSelected = true;
    }
}


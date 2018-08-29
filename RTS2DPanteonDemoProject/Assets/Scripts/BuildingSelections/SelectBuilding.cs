using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBuilding : MonoBehaviour
{
    [SerializeField]
    bool canSpawnSolider;
    [SerializeField]
    Sprite UnitSprite;
    [SerializeField]
    Sprite SoliderSprite;
    // Use this for initialization
    protected const string SoliderTagName= "Solider";
    void Start()
    {

    }
    private void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // Get Info On Panel
          //   InfoPanel gmInfo = GameObject.FindObjectOfType<InfoPanel>();
            BuildingView gmBuildingView = GameObject.FindObjectOfType<BuildingView>();
            gmBuildingView.SetView(UnitSprite,canSpawnSolider,SoliderSprite,transform.position, SoliderTagName);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

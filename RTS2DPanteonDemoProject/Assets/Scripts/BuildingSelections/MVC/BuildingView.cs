
using UnityEngine;
using UnityEngine.UI;

public class BuildingView : MonoBehaviour {
    public BuildingController controller;
    public Image SelectedUnitSprite;
    public Button SoliderCreate;
    private Sprite SoliderSprite;
    private CreateGameObjects gmObj;
    private bool canSpawnSoliderHere=false;
    private void Start()
    {
        gmObj = CreateGameObjects.Instance;
        SoliderSprite = SoliderCreate.GetComponent<Image>().sprite;
        InitView();
    }
    public void InitView()
    {
        SelectedUnitSprite.sprite = controller.GetBuildingSprite();
        SoliderSprite = controller.GetSoliderSprite();

    }

    // Use this for initialization
    public void SetView(Sprite UnitSprite,bool canSpawnSolider,Sprite soliderSprite,Vector2 pos,string tagname)
    {
        SoliderCreate.onClick.RemoveAllListeners();
        SelectedUnitSprite.sprite = UnitSprite;
        if (canSpawnSolider)
        {
            SoliderCreate.onClick.AddListener(()=>CreateSolider(pos,tagname));
            controller.SetSoliderSprite(SoliderSprite);
            SoliderCreate.GetComponent<Image>().sprite = soliderSprite;
        }
        else
        {
            SoliderCreate.GetComponent<Image>().sprite = controller.SetNoUnitSprite();
        }
    }
    public void CreateSolider(Vector2 buildingPosition,string tagName)
    {
      
        GameObject gmSolider= gmObj.CreateGameObject(tagName, buildingPosition,null);
        gmSolider.GetComponent<InitSolider>().SetBuildingPosition(buildingPosition);
    }
   


}

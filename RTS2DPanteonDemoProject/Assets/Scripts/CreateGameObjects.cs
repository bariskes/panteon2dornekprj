using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// inherits from Singleton class to make singleton
public class CreateGameObjects : MakeSingleton<CreateGameObjects>
{
    public Transform Parent;
    [SerializeField]
    private List<Pool> gameObjectList;
    private PoolDictionary poolDic;
    

    [SerializeField]
    private List<GameObject> gmSelectedGameObjects;
    private Transform destinatinTransform;
    void Start()
    {
        destinatinTransform = this.GetComponent<Transform>();
        poolDic = PoolDictionary.Instance;
        poolDic.setPool(gameObjectList, Parent);
    }
    private void Update()
    {
        // on right click if is there any of selected units set  Target point for those units
   
        if (Input.GetMouseButtonDown(1))// right click
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destinatinTransform.position = mousePos;
            foreach (GameObject item in gmSelectedGameObjects)
            {
                // sets selected objects destination
                item.GetComponent<InitSolider>().IsMoving = true;
                destinatinTransform.position = new Vector2(destinatinTransform.position.x, destinatinTransform.position.y);
                item.GetComponent<AIDestinationSetter>().target = destinatinTransform;
                item.GetComponent<AIDestinationSetter>().targetVectorInfo = destinatinTransform.position;
            }
            
        }
    }
    public  GameObject  CreateGameObject(string TagName,Vector2 pos,Transform parent)
    {
        return poolDic.SpawnFromPool(TagName, pos,parent);
    }
    public int AddOnScreenSelectedGameObject(GameObject gmObj)
    {
        gmSelectedGameObjects.Add(gmObj);
        return gmSelectedGameObjects.IndexOf(gmObj); // son insert edilen index
    }
    public void RemoveOnScreenSelectedGameObject()
    {
        gmSelectedGameObjects.Clear();
      
    }
   

}

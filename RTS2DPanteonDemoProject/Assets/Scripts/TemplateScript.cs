using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateScript : MonoBehaviour {

    [SerializeField]
    private string finalObjectTag;
    [SerializeField]
    private LayerMask allTilesLayer;
    private Vector2 mousePos;
    private CreateGameObjects gmObj;
    [HideInInspector]
    public float Cubex;
    [HideInInspector]
    public float Cubey;
    // creates transparant version ifs its true
    [SerializeField]
    public bool isSelected = false;
    private void Start()
    {
        gmObj = CreateGameObjects.Instance;
    }

	void Update () {
        if (!isSelected)
            return;
        SetPosition();
    }

    private void OnDrawGizmos()
    {
      Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
          Gizmos.DrawWireCube(transform.position, new Vector2(Cubex,Cubey));
    }

    // sets position of grid
    void SetPosition()
    {
       
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // gets integer parts of mouse pos
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
      
        if (Input.GetMouseButtonDown(0))
        {
            //creates a unvisible box as big as gameobjects bounds
            Collider2D ray = Physics2D.OverlapBox(transform.position, new Vector2(Cubex,Cubey),0, allTilesLayer) ;

            if (ray == null)
            {
                // creates object from pool
                gmObj.CreateGameObject(finalObjectTag, transform.position, null);
                isSelected = false;
                Destroy(this.gameObject);
                // temporary green color
               
            }
            else
            {
                /// temporary red color/
                SetColorTemp(Color.red);

            }

        }

    }
     

    void SetColorTemp(Color clr)
    {
        // this corotine is  to show  if objects is not possible to place
        StartCoroutine(ChangeColorTemporary(clr));
    }

    IEnumerator ChangeColorTemporary(Color clr)
    {
        this.GetComponent<SpriteRenderer>().material.color = clr;
        yield return new WaitForSeconds(0.75f);
        this.GetComponent<SpriteRenderer>().material.color =Color.white;

    }

}

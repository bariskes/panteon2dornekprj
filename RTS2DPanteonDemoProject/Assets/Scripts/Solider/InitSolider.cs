using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSolider : MonoBehaviour
{
    public bool IsMoving = false;
    public LayerMask mask;
    public float radius = 32F;
    private Vector2 buildingPos;
    private Vector2 pos;
    private Rigidbody2D rgdBody;
    private bool checkedInit = false;
    // static layer names to  filter
    private static string building = "Buildings";
    private static string solider = "Solider";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string LayerName = LayerMask.LayerToName(collision.gameObject.layer);
        if (!checkedInit)
        {
            //if this is first spawn time and hits the building
            if (LayerName == building)
            {
                
                // scan  point and set it as destination
                GameObject.FindObjectOfType<AstarPath>().Scan();
                Vector2 posvector=collision.gameObject.transform.position;
                transform.position=new Vector2(posvector.x + 4F, posvector.y);
                gameObject.GetComponent<AIDestinationSetter>().target = collision.gameObject.transform;
                gameObject.GetComponent<AIDestinationSetter>().targetVectorInfo = posvector;
            }
            checkedInit = true;
            if (LayerName == solider && IsMoving == false) // if solider is not moveing
            {
               
                Vector2 otherSolider = collision.gameObject.transform.position;
                Vector2 thisSolider = transform.position;
                float x = Random.Range(-2F, 2F);
                float y = Random.Range(-2F, 2F);
                // move solider in random direction
                transform.Translate(new Vector3(thisSolider.x + x, thisSolider.y + y));
            }
        }

       
    }

  
    public void SetBuildingPosition(Vector2 pos)
    {
        buildingPos = pos;
    }
  







}

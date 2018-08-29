using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSolider : MonoBehaviour
{

    [SerializeField]
    private Color SelectedColor;
    public bool IsSelected = false;
    [SerializeField]
    private float ClosestPoint=0.8F;

    private SpriteRenderer SoliderSprite;
    private CreateGameObjects gmObs;
    private Transform destination;
    private int ItemIndex = 0;
    void Start()
    {
        gmObs = CreateGameObjects.Instance;
        SoliderSprite = this.GetComponent<SpriteRenderer>();
       
    }
    

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) // makeSelected
        {

            SetStatus(true);
        }
    }
    void SetStatus(bool status)
    {

        IsSelected = status;
        if (IsSelected)
        {
            SoliderSprite.color = SelectedColor;
            ItemIndex = gmObs.AddOnScreenSelectedGameObject(gameObject);
            GameObject.FindObjectOfType<AstarPath>().Scan();
        }
        else
        {
            SoliderSprite.color = Color.white;
            gmObs.RemoveOnScreenSelectedGameObject();
        }

    }
    void LateUpdate()
    {
      
        if (Input.GetMouseButtonDown(1))
        {
            SetStatus(false);
        }
        // if distance between target and solider pos is smaller than minimum
        // then stop moving.
        destination = destination = this.GetComponent<AIDestinationSetter>().target;
        if (destination != null)
        {
            float minPoint=  Vector2.Distance(transform.position, destination.position);
            if (minPoint < ClosestPoint)
            {
                this.GetComponent<AIDestinationSetter>().target = null;
                this.GetComponent<AILerp>().canMove = false;
                GetComponent<InitSolider>().IsMoving = false;
            }
            else
            {
                this.GetComponent<AILerp>().canMove = true;
                GetComponent<InitSolider>().IsMoving = true;
            }
        }
    }
}

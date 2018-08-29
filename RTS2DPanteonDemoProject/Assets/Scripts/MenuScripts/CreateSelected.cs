using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSelected : MonoBehaviour
{
    TemplateScript tmp = null;
    public void CreateSelectedItem(GameObject GmObj)
    {
        GameObject g = (GameObject)Instantiate(GmObj, transform.position, Quaternion.identity);
        TemplateScript temps = g.GetComponent<TemplateScript>();
        // crates visibility
        temps.isSelected = true;
      //  temps.Cubex = Cubex;
      //  temps.Cubey = Cubey;


    }
}

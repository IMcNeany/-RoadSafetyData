using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSpawnChicken : MonoBehaviour
{
    Ray myRay;      
    RaycastHit hit; 
    public GameObject objectToinstantiate;
    void Update()
    {
        // telling my ray variable that the ray will go from the center of my main camera to my mouse (This will give me a direction)
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // if ray hits the ground store the info on it
        if (Physics.Raycast(myRay, out hit))
        { 
            if (Input.GetMouseButtonDown(0))
            {
                // instatiate a prefab on the position where the ray hits the floor.
                Instantiate(objectToinstantiate, hit.point, Quaternion.identity); 
            }
        } 
    }
}

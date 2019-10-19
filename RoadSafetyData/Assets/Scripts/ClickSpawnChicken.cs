using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSpawnChicken : MonoBehaviour
{
    Ray myRay;      // initializing the ray
    RaycastHit hit; // initializing the raycasthit
    public GameObject objectToinstantiate;
    void Update()
    {
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition); // telling my ray variable that the ray will go from the center of 
                                                                   // my main camera to my mouse (This will give me a direction)

        if (Physics.Raycast(myRay, out hit))
        { // here I ask : if myRay hits something, store all the info you can find in the raycasthit varible.
          // things like the position where the hit happend, the name of the object that got hit etc..etc..

            if (Input.GetMouseButtonDown(0))
            {// what to do if i press the left mouse button
                Instantiate(objectToinstantiate, hit.point, Quaternion.identity);// instatiate a prefab on the position where the ray hits the floor.
                Debug.Log(hit.point);// debugs the vector3 of the position where I clicked
            }// end upMousebutton
        }// end physics.raycast    
    }
     /*
         public GameObject chicken;

         public void Spawn(Vector3 position)
         {
             Instantiate(chicken).transform.position = position;
         }

         // Update is called once per frame
         public void Update()
         {
             if (Input.GetKeyDown(KeyCode.Mouse0))
             {
                 Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
                 Spawn();
             }
         }
     */
}

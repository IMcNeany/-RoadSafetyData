using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPostSettings : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> lampPosts;
    // Start is called before the first frame update
    void Start()
    {
        lampPosts = new List<GameObject>();
        lampPosts.AddRange( GameObject.FindGameObjectsWithTag("Lamp"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableLight()
    {
        ToggleLight(false);
    }


    public void EnableLight()
    {
        ToggleLight(true);
    }

   
    private void ToggleLight(bool active)
    {
        for (int i = 0; i < lampPosts.Count; i++)
        {
            lampPosts[i].transform.GetChild(0).gameObject.SetActive(active);
        }
    }

    public void DisableLampPosts()
    {
        ToggleLampPosts(false);
    }


    public void EnableLampPosts()
    {
        ToggleLampPosts(true);
    }

    private void ToggleLampPosts(bool active)
    {
        for (int i = 0; i < lampPosts.Count; i++)
        {
            lampPosts[i].SetActive(active);
        }
    }
}

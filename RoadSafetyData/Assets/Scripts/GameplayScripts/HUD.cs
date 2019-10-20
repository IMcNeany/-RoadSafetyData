using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text data_text;
    private string crossing_type = "pedestrian";
    private string test = "60%";
    private string n_accidents = "50";
    private string severity = "deadly";

    // Start is called before the first frame update
    void Start()
    {
        data_text.text = "Crossing Type: " + crossing_type + "\nNumber of accidents: " + n_accidents + "\nOverall severity: " + severity + "\nDeath chance: " + test;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScene : MonoBehaviour
{

    public GameObject fog;
    public GameObject rain;
    public GameObject snow;
    public TMPro.TMP_Dropdown weatherDropBox;

    public GameObject daylight;
    public GameObject night;
    public LampPostSettings lampPosts;
    public TMPro.TMP_Dropdown LightingDropBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnWeatherChanged()
    {
       int newValue = weatherDropBox.value;
        switch (newValue)
        {
            case 0:
                //none
                DeactivateWeather();
                break;
            case 1:
                //normal
                DeactivateWeather();
                break;
            case 2:
                //rain
                DeactivateWeather();
                rain.SetActive(true);
                break;
            case 3:
                //snow
                DeactivateWeather();
                snow.SetActive(true);
                break;
            case 4:
                //fog
                DeactivateWeather();
                fog.SetActive(true);
                break;
           
        }
    }

    void DeactivateWeather()
    {
        fog.SetActive(false);
        rain.SetActive(false);
        snow.SetActive(false);
    }

    public void OnLightingChanged()
    {
        int newValue = LightingDropBox.value;
        switch (newValue)
        {
            case 0:
                //none
                DeactivateLighting();
                break;
            case 1:
                //daylight
                DeactivateLighting();
                daylight.SetActive(true);
                break;
            case 2:
                //streetlamp
                DeactivateLighting();
                lampPosts.EnableLight();
                break;
            case 3:
                //darkness
                DeactivateLighting();
                night.SetActive(true);
                break;
        }
    }

    void DeactivateLighting()
    {
        daylight.SetActive(false);
        night.SetActive(false);
        lampPosts.DisableLight();
    }


}

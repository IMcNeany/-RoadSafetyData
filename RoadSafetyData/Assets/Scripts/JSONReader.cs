using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Items
{
    public string Accident_Index;
    public string Vehicle_Reference;
    public string Casualty_Reference;
    public string Casualty_Class;
    public string Sex_of_Casualty;
    public string Age_of_Casualty;
    public string Age_Band_of_Casualty;
    public string Casualty_Severity;
    public string Pedestrian_Location;
    public string Pedestrian_Movement;
    public string Car_Passenger;
    public string Bus_or_Coach_Passenger;
    public string Pedestrian_Road_Maintenance_Worker;
    public string Casualty_Type;
    public string Casualty_Home_Area_Type;
    public string Casualty_IMD_Decile;
    public string Location_Easting_OSGR;
    public string Location_Northing_OSGR;
    public string Longitude;
    public string Latitude;
    public string Police_Force;
    public string Accident_Severity;
    public string Number_of_Vehicles;
    public string Number_of_Casualties;
    public string Date;
    public string Day_of_Week;
    public string Time;
    public string Local_Authority_District;
    public string Local_Authority_Highway;
    public string Road_class_one;
    public string Road_number_one;
    public string Road_Type;
    public string Speed_limit;
    public string Junction_Detail;
    public string Junction_Control;
    public string Road_class_two;
    public string Road_number_two;
    public string Pedestrian_Crossing_Human_Control;
    public string Pedestrian_Crossing_Physical_Facilities;
    public string Light_Conditions;
    public string Weather_Conditions;
    public string Road_Surface_Conditions;
    public string Special_Conditions_at_Site;
    public string Carriageway_Hazards;
    public string Urban_or_Rural_Area;
    public string Did_Police_Officer_Attend_Scene_of_Accident;
    public string LSOA_of_Accident_Location;
}

[System.Serializable]
public class Rootobject
{
    public List<Items> jsonObject;
}


public class JSONReader : MonoBehaviour
{
    
    public Rootobject loadedData;

    // Start is called before the first frame update
    void Start()
    {
        loadedData = new Rootobject();
        LoadJSON();
    }

    void LoadJSON()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "SafetyDataJSON.Json");

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
             loadedData = JsonUtility.FromJson<Rootobject>("{\"jsonObject\":" + dataAsJson + "}");
            
        }
        else
        {
            Debug.Log("Error to open JSON");
        }

        GetJsonData(0, "Accident_Index");
        }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetJsonData(int objectNo, string objectData)
    {

        string JsonObject = loadedData.jsonObject[objectNo].ToString();
        //loadedData.jsonObject[objectNo].ToString();
        // Debug.Log(loadedData.jsonObject[0].Pedestrian_CrossingPhysical_Facilities.ToString());

        //in a loop
        //usableData new data
        //new data.time = JsonObject.Items[3]["time"].Tostring;
        //data.weather = JsonObject.Items[3].weather;
        return "JsonObject";
    }
}

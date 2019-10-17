using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Rootobject
{

    public Items[] jsonObject { get; set; }
}

[System.Serializable]
public class Items
{
    public string Accident_Index { get; set; }
    public string Vehicle_Reference { get; set; }
    public string Casualty_Reference { get; set; }
    public string Casualty_Class { get; set; }
    public string Sex_of_Casualty { get; set; }
    public string Age_of_Casualty { get; set; }
    public string Age_Band_of_Casualty { get; set; }
    public string Casualty_Severity { get; set; }
    public string Pedestrian_Location { get; set; }
    public string Pedestrian_Movement { get; set; }
    public string Car_Passenger { get; set; }
    public string Bus_or_Coach_Passenger { get; set; }
    public string Pedestrian_Road_Mastringenance_Worker { get; set; }
    public string Casualty_Type { get; set; }
    public string Casualty_Home_Area_Type { get; set; }
    public string Casualty_IMD_Decile { get; set; }
    public string Location_Easting_OSGR { get; set; }
    public string Location_Northing_OSGR { get; set; }
    public string Longitude { get; set; }
    public string Latitude { get; set; }
    public string Police_Force { get; set; }
    public string Accident_Severity { get; set; }
    public string Number_of_Vehicles { get; set; }
    public string Number_of_Casualties { get; set; }
    public string Date { get; set; }
    public string Day_of_Week { get; set; }
    public string Time { get; set; }
    public string Local_Authority_District { get; set; }
    public string Local_Authority_Highway { get; set; }
    public string _1st_Road_Class { get; set; }
    public string _1st_Road_Number { get; set; }
    public string Road_Type { get; set; }
    public string Speed_limit { get; set; }
    public string Junction_Detail { get; set; }
    public string Junction_Control { get; set; }
    public string _2nd_Road_Class { get; set; }
    public string _2nd_Road_Number { get; set; }
    public string Pedestrian_CrossingHuman_Control { get; set; }
    public string Pedestrian_CrossingPhysical_Facilities { get; set; }
    public string Light_Conditions { get; set; }
    public string Weather_Conditions { get; set; }
    public string Road_Surface_Conditions { get; set; }
    public string Special_Conditions_at_Site { get; set; }
    public string Carriageway_Hazards { get; set; }
    public string Urban_or_Rural_Area { get; set; }
    public string Did_Police_Officer_Attend_Scene_of_Accident { get; set; }
    public string LSOA_of_Accident_Location { get; set; }
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
            Debug.Log(loadedData.jsonObject[0].Speed_limit);
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

        Debug.Log("JSON: " + JsonObject);
        //in a loop
        //usableData new data
        //new data.time = JsonObject.Items[3]["time"].Tostring;
        //data.weather = JsonObject.Items[3].weather;
        return "JsonObject";
    }
}

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
    public DataCruncher cruncher;

    public void LoadJSON()
    {
        loadedData = new Rootobject();
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
        JsonDataToUsableData();
    }


    public void JsonDataToUsableData()
    {
        for(int i = 0; i < loadedData.jsonObject.Count; i++)
        {
            UsableData new_data = new UsableData();
            //check if the accident involves a pedestrian casualty, otherwise we skip it
            if(new_data.ConvertStringToLocation(loadedData.jsonObject[i].Pedestrian_Location) == accident_location.none)
            {
                continue;
            }
            //here we load the data into usable data formats
            new_data.location = new_data.ConvertStringToLocation(loadedData.jsonObject[i].Pedestrian_Location);
            new_data.severity = new_data.ConvertStringToSeverity(loadedData.jsonObject[i].Casualty_Severity);
            new_data.weather = new_data.ConvertStringToWeather(loadedData.jsonObject[i].Weather_Conditions);
            new_data.lighting = new_data.ConvertStringToLighting(loadedData.jsonObject[i].Light_Conditions);
            new_data.day = new_data.ConvertStringToWeekday(loadedData.jsonObject[i].Day_of_Week);
            new_data.age = int.Parse(loadedData.jsonObject[i].Age_of_Casualty);
            new_data.time = new_data.ConvertStringToTime(loadedData.jsonObject[i].Time);
            new_data.speed = int.Parse(loadedData.jsonObject[i].Speed_limit);

            //add it to the cruncher so it can create statistics based on the new datas
            cruncher.AddDataToList(new_data);

        }
    }

}

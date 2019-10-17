using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum accident_locations
{
    none,
    crossing,
    approach,
    exit,
    nearby,
    carriageway,
    pavement,
    NUMSTATS
}

public enum accident_severity
{
    slight,
    serious,
    fatal,
    NUMSTATS
}

public enum accident_weather
{
    none,
    normal,
    rain,
    snow,
    fog,
    NUMSTATS
}

public enum accident_weekday
{
    monday,
    tuesday,
    wednesday,
    thursday,
    friday,
    saturday,
    sunday,
    NUMSTATS
}

public enum accident_lighting
{
    none,
    daylight,
    streetlamp,
    darkness,
    NUMSTATS
}


//Usable data is created with specific variables from the main data file
[System.Serializable]
public class UsableData
{
    public accident_locations location;
    public accident_severity  severity;
    public accident_weather   weather;
    public accident_lighting  lighting;
    public accident_weekday   day;
    public int                age;
    public int                time;
    public int                speed;

    public accident_locations ConvertStringToLocation(string str)
    {
        accident_locations new_location = accident_locations.crossing;
     
        switch(str)
        {
            case "1":
                new_location = accident_locations.crossing;
                break;
            case "2":
                new_location = accident_locations.approach;
                break;
            case "3":
                new_location = accident_locations.exit;
                break;
            case "4":
                new_location = accident_locations.nearby;
                break;
            case "5":
                new_location = accident_locations.carriageway;
                break;
            case "6":
                new_location = accident_locations.pavement;
                break;
            case "7":
                new_location = accident_locations.carriageway;
                break;
            case "8":
                new_location = accident_locations.carriageway;
                break;
            case "9":
                new_location = accident_locations.carriageway;
                break;
            default:
                new_location = accident_locations.none;
                break;
        }
        return new_location;
    }

    public accident_severity ConvertStringToSeverity(string str)
    {
        accident_severity new_severity = accident_severity.slight;

        switch (str)
        {
            case "1":
                new_severity = accident_severity.fatal;
                break;
            case "2":
                new_severity = accident_severity.serious;
                break;
            case "3":
                new_severity = accident_severity.slight;
                break;
        }
        return new_severity;
    }

    public accident_weather ConvertStringToWeather(string str)
    {
        accident_weather new_weather = accident_weather.normal;
        switch (str)
        {
            case "1":
                new_weather = accident_weather.normal;
                break;
            case "2":
                new_weather = accident_weather.rain;
                break;
            case "3":
                new_weather = accident_weather.snow;
                break;
            case "4":
                new_weather = accident_weather.normal;
                break;
            case "5":
                new_weather = accident_weather.rain;
                break;
            case "6":
                new_weather = accident_weather.snow;
                break;
            case "7":
                new_weather = accident_weather.fog;
                break;
            default:
                new_weather = accident_weather.none;
                break;
        }
        return new_weather;
    }

    public accident_lighting ConvertStringToLighting(string str)
    {
        accident_lighting new_severity = accident_lighting.daylight;

        switch (str)
        {
            case "1":
                new_severity = accident_lighting.daylight;
                break;
            case "4":
                new_severity = accident_lighting.streetlamp;
                break;
            case "5":
                new_severity = accident_lighting.darkness;
                break;
            case "6":
                new_severity = accident_lighting.darkness;
                break;
            default:
                new_severity = accident_lighting.none;
                break;
        }
        return new_severity;
    }

    public accident_weekday ConvertStringToWeekday(string str)
    {
        accident_weekday new_day = accident_weekday.monday;

        switch(str)
        {
            case "1":
                new_day = accident_weekday.sunday;
                break;
            case "2":
                new_day = accident_weekday.monday;
                break;
            case "3":
                new_day = accident_weekday.tuesday;
                break;
            case "4":
                new_day = accident_weekday.wednesday;
                break;
            case "5":
                new_day = accident_weekday.thursday;
                break;
            case "6":
                new_day = accident_weekday.friday;
                break;
            case "7":
                new_day = accident_weekday.saturday;
                break;
        }

        return new_day;
    }

    public int ConvertStringToTime(string str)
    {
        string hour_str = str[0] + "" + str[1];
        int hour_int = int.Parse(hour_str);
        return hour_int;
    }
}

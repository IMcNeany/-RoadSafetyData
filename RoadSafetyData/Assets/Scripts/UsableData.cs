using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum accident_locations
{
    crossing,
    approach,
    nearby,
    carriageway,
    pavement
}

public enum accident_severity
{
    slight,
    serious,
    fatal
}

public enum weather_conditions
{
    normal,
    rain,
    snow
}

public enum weekday
{
    monday,
    tuesday,
    wednesday,
    thursday,
    friday,
    saturday,
    sunday
}

public enum lighting
{
    daylight,
    streetlamp,
    darkness
}


//Usable data is created with specific variables from the main data file
public class UsableData : MonoBehaviour
{
    public accident_locations location;
    public accident_severity severity;
    public int age;
    public weather_conditions weather;
    public weekday day;
    public int time;
    public int speed;
}

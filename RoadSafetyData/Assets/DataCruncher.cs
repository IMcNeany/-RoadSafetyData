using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WeatherChance
{
    public accident_weather type;
    public int amount;
    public float percentage_chance;
}

[System.Serializable]
public class DataCruncher : MonoBehaviour
{
    public List<UsableData> usable_data_list;
    public List<WeatherChance> weather_chances;
//--------------------------------------------------------
    private int num_accidents_in_year;
    private int num_people_uk = 66040000;

    public void AddDataToList(UsableData data)
    {
        usable_data_list.Add(data);
    }

    public void CrunchNumbers()
    {
        num_accidents_in_year = usable_data_list.Count;
        GetWeatherChances();
    }

    public void GetWeatherChances()
    {
        if(weather_chances != null)
        {
            weather_chances.Clear();
        }

        int total = usable_data_list.Count;

        for(int i = 0; i < (int)accident_weather.NUMSTATS; i++)
        {
            WeatherChance new_chance;
            int count = 0;
            for(int j = 0; j < usable_data_list.Count; j++)
            {
                if((int)usable_data_list[j].weather == i)
                {
                    count++;
                }
            }
            new_chance.type = (accident_weather)i;
            new_chance.amount = count;

            new_chance.percentage_chance = count / num_accidents_in_year * 100;

            weather_chances.Add(new_chance);
        }
    }
}

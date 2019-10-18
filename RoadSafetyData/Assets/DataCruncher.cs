using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatChance
{
    public int amount = 0;
    public float percentage_chance = 0;
    public string enum_type;
}

[System.Serializable]
public class DataCruncher : MonoBehaviour
{
    public List<UsableData> usable_data_list;
    public List<StatChance> weather_chances;
    public List<StatChance> location_chances;
    public List<StatChance> speed_chances;
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
        GetChances(weather_chances, "accident_weather");
        GetChances(location_chances, "accident_location");
        GetChances(speed_chances, "speed");
    }

    public void GetChances(List<StatChance> stat_list, string enum_string)
    {
        List<int> temp_data = new List<int>();
        if(stat_list != null)
        {
            stat_list.Clear();
        }

        int total = usable_data_list.Count;

        switch(enum_string)
        {
            case "accident_weather":
                for (int i = 0; i < (int)accident_weather.NUMSTATS; i++)
                {
                    int count = 0;
                    for (int j = 0; j < usable_data_list.Count; j++)
                    {
                        if ((int)usable_data_list[j].weather == i)
                        {
                            count++;
                        }
                    }
                    StatChance new_chance = new StatChance();
                    new_chance.amount = count;
                    var weather_status = (accident_weather)i;
                    new_chance.enum_type = weather_status.ToString();
                    new_chance.percentage_chance = (float)count / (float)num_accidents_in_year * 100;
                    stat_list.Add(new_chance);
                }
                break;
            case "accident_location":
                for (int i = 0; i < (int)accident_location.NUMSTATS; i++)
                {
                    int count = 0;
                    for (int j = 0; j < usable_data_list.Count; j++)
                    {
                        if ((int)usable_data_list[j].location == i)
                        {
                            count++;
                        }
                    }
                    StatChance new_chance = new StatChance();
                    new_chance.amount = count;
                    var location_status = (accident_location)i;
                    new_chance.enum_type = location_status.ToString();
                    new_chance.percentage_chance = (float)count / (float)num_accidents_in_year * 100;
                    stat_list.Add(new_chance);
                }
                break;
            case "speed":
                for (int i = 0; i < 100; i++)
                {
                    int count = 0;
                    for (int j = 0; j < usable_data_list.Count; j++)
                    {
                        if ((int)usable_data_list[j].speed == i)
                        {
                            count++;
                        }
                    }
                    if(count == 0)
                    {
                        continue;
                    }
                    StatChance new_chance = new StatChance();
                    new_chance.amount = count;
                    var location_status = (accident_location)i;
                    new_chance.enum_type = location_status.ToString();
                    new_chance.percentage_chance = (float)count / (float)num_accidents_in_year * 100;
                    stat_list.Add(new_chance);
                }
                break;
        }
    }
}

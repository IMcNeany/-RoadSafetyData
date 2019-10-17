using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int                  speed_of_cars = 0;
    public accident_weather   current_weather;
    public int                  current_day;
    public int                  current_time;
//----------------------------------------------------------------
    public float                default_hit_chance;
    [SerializeField]
    private List<float>         weather_multipliers;
    [SerializeField]
    private List<float>         day_multipliers;
    [SerializeField]
    private List<float>         time_multipliers;

    private DataCruncher        data_cruncher;
    private JSONReader          json_reader;
    public float                percentage_accident;

    void Start()
    {
        json_reader = GetComponentInChildren<JSONReader>();
        data_cruncher = GetComponentInChildren<DataCruncher>();

        json_reader.LoadJSON();
        data_cruncher.CrunchNumbers();
        UpdatePercentageAccident();
    }

    public void UpdatePercentageAccident()
    {
        //percentage_accident = (float)num_accidents_in_year / (float)num_people_uk * 100.0f;
    }

    //default chance of accident without pedestrian data
    public void UpdateHitChance()
    {
        UpdatePercentageAccident();
        default_hit_chance = 0 + (speed_of_cars / 100) * weather_multipliers[(int)current_weather] * day_multipliers[current_day] * time_multipliers[current_time];

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private float weatherChance = 0.0f;
    private float dayChance =0;
    private float lightingChance = 0;
    private float severityChance =0;

    [SerializeField] private GameObject _chart;


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
        //get chances from current stats
        //percentage_accident = (float)num_accidents_in_year / (float)num_people_uk * 100.0f;

        percentage_accident = (weatherChance + dayChance + lightingChance + severityChance) / 4;

        _chart.transform.GetChild(0).GetComponent<Image>().fillAmount = percentage_accident / 100;
    }

    //default chance of accident without pedestrian data
    public void UpdateHitChance()
    {
        UpdatePercentageAccident();
        default_hit_chance = 0 + (speed_of_cars / 100) * weather_multipliers[(int)current_weather] * day_multipliers[current_day] * time_multipliers[current_time];

    }

    public void CalculateFinalChance(int dataNo, string property)
    {
        //really bad way of doing this

        switch(property)
        {
            case "weather":
                {
                    weatherChance = data_cruncher.weather_chances[dataNo].percentage_chance;
                }
                break;
            case "day":
                {
                    dayChance = data_cruncher.day_chances[dataNo].percentage_chance;
                }
                break;
            case "lighting":
                {
                    lightingChance = data_cruncher.light_chances[dataNo].percentage_chance;
                }
                break;
            case "severity":
                {
                    severityChance = data_cruncher.fatality_chances[dataNo].percentage_chance;
                }
                break;
        }

        UpdatePercentageAccident();
    }
}

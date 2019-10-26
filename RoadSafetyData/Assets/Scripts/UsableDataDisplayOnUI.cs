using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

// This class goes through the array of string names of enums and adds the enum names to the dropdown on UI.

public class UsableDataDisplayOnUI : MonoBehaviour
{
    [SerializeField] string[] _namesOfEnums;

    void Start()
    {
        InitialiseNamesOfEnumsArray();

        for (int i = 0; i < _namesOfEnums.Length; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<TMP_Dropdown>().ClearOptions();
            // Create a list
            List<string> tempList = new List<string>();
            tempList = Enum.GetNames(Type.GetType(_namesOfEnums[i])).ToList();
            // Remove last element 
            tempList.RemoveAt(tempList.Count - 1);
            // Pass to the dropdown
            gameObject.transform.GetChild(i).GetComponent<TMP_Dropdown>()
                .AddOptions(tempList);
        }
    }

    private void InitialiseNamesOfEnumsArray()
    {
        _namesOfEnums = new string[5];
        _namesOfEnums[0] = typeof(accident_location).FullName;
        _namesOfEnums[1] = typeof(accident_weather).FullName;
        _namesOfEnums[2] = typeof(accident_weekday).FullName;
        _namesOfEnums[3] = typeof(accident_lighting).FullName;
        _namesOfEnums[4] = typeof(accident_severity).FullName;
    }
}
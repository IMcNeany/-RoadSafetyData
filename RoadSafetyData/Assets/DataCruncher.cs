using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataCruncher : MonoBehaviour
{
    public List<UsableData> usable_data_list;

    public void AddDataToList(UsableData data)
    {
        usable_data_list.Add(data);
    }

    public void CrunchNumbers()
    {

    }
}

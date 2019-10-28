using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class looks for X amount of random people objects in the object pool
// Sets the bool isRogue to true and changes the colour of the go's material to yellow
// Objects with isRogue = true will cross the road on red light

public class ChanceManager : MonoBehaviour
{
    [SerializeField] private ObjectPooler _op;
    [SerializeField] private GameManager _gm;

    List<int> randomNumbers = new List<int>();


    [ContextMenu("SetIsRogueForRandomPeople")]
    public void SetIsRogueForRandomPeople()
    {
        ChooseRandomPeople((int) _gm.percentage_accident);
    }

    void ChooseRandomPeople(int peopleAmount)
    {
        var max = _op.object_pool.Count - 1;

        // Clean up the list
        randomNumbers.Clear();
        randomNumbers.TrimExcess();

        if (max <= peopleAmount) return;
        for (int i = 0; i < peopleAmount; i++)
        {
            while (randomNumbers.Count <= peopleAmount - 1)
            {
                var randomInt = Random.Range(0, max);
                if (!randomNumbers.Contains(randomInt))
                {
                    randomNumbers.Add(randomInt);

                    // set the random object's isRogue to true this will make people cross on the red light
                    _op.object_pool[randomInt].gameObject.GetComponent<PersonMovement>().isRogue = true;
                    _op.object_pool[randomInt].gameObject.transform.GetComponentInChildren<Renderer>().material
                        .SetColor("_Color", Color.yellow);
                }
            }
        }
    }
    
}
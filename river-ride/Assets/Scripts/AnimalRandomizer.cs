using System.Collections.Generic;
using UnityEngine;

public class AnimalRandomizer : MonoBehaviour
{
    public GameObject[] animalEvents; // List of animal prefabs to choose from
    public int eventCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < animalEvents.Length; i++)
        {
            animalEvents[i].SetActive(false);
        }
        if ((animalEvents.Length) <= eventCount)
        {
            eventCount = animalEvents.Length;
        }
        List<int> selectedIndices = new List<int>();
        while (selectedIndices.Count < eventCount)
        {
            int randomIndex = Random.Range(0, animalEvents.Length);
            if (!selectedIndices.Contains(randomIndex))
            {
                selectedIndices.Add(randomIndex);
                animalEvents[randomIndex].SetActive(true); // Activate the selected animal event]
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

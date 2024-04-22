using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterCreator : MonoBehaviour
{
    public List<Counter> RequestedCounters;
    // Start is called before the first frame update
    void Start()
    {
        RequestedCounters = new List<Counter>();
    }
    private void OnEnable()
    {
        EventManager.OnRequirementsSetEvent += CreateCounters;
        EventManager.OnRemoveRequirementsEvent += CleanUpCountersList;
    }
    private void OnDisable()
    {
        EventManager.OnRequirementsSetEvent -= CreateCounters;
        EventManager.OnRemoveRequirementsEvent -= CleanUpCountersList; 
        
    }
    public void CreateCounters(Dictionary<GameObject, int> placedCandiesDictionary)
    {
        foreach (KeyValuePair<GameObject, int> kvp in placedCandiesDictionary)
        {
            RequestedCounters.Add(new Counter(kvp.Key.tag));
        }
        EventManager.CountersSetEvent(RequestedCounters);
    }

    public void CleanUpCountersList()
    {
        RequestedCounters.Clear();
    }
}

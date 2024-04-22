using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotStand : MonoBehaviour
{
    private CounterCreator creator;
    private RequestedItems requested;
    private bool []Passed;

    private List<int> valuesToCheck;
    // Start is called before the first frame update
    void Start()
    {
        creator = FindAnyObjectByType<CounterCreator>();
        requested = FindAnyObjectByType<RequestedItems>();
        Passed = new bool[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
   
    }
    private void OnDisable()
    {
     
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Counter"))
        {
            CheckRequest();
        }
    }

    
    private void CheckRequest()
    {
        var counters = creator.RequestedCounters;
        foreach (KeyValuePair<GameObject, int> kvp in requested._placedCandys)
        {
            foreach (var counter in counters)
            {
                if(counter.Name==kvp.Key.tag)
                {
                    Passed[0] = counter.Count.Equals(kvp.Value);
                    Debug.Log(Passed[0].ToString() + Passed[1].ToString() + Passed[2].ToString()) ;
                }
                   
            }
        }
       
    }
}

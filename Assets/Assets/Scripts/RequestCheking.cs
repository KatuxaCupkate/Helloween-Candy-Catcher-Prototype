using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestCheking : MonoBehaviour
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
        int i = 0;
        var counters = creator.RequestedCounters;
        foreach (KeyValuePair<GameObject, int> req in requested._placedCandys)
        {
            foreach (var counter in counters)
            {
                if(counter.Name==req.Key.tag)
                {
                    if (i >= Passed.Length)
                        break;
                    Passed[i] = counter.Count.Equals(req.Value);
                    i++;
                    continue;
                }
                   
            }
        }
 
        if (Passed[0] && Passed[1]&& Passed[2])
        {

          Debug.Log($"All passed");
        }
    }
}

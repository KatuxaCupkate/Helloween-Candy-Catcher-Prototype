using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCatcher : MonoBehaviour
{
    [SerializeField] private ObjectPool pool;
    private CounterCreator counterCreator;

    // Start is called before the first frame update
    void Start()
    {
        counterCreator = GetComponent<CounterCreator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ChangeCount(other);
        pool.ReturnToPool(other.GetComponent<PooledObject>());
    }

    private void ChangeCount(Collider other)
    {
        foreach (var counter in counterCreator.RequestedCounters)
        {
            if (other.CompareTag(counter.Name))
            {
                counter.IncrementCount();
            }
        }
        EventManager.CountChangedEvent();
    }
}

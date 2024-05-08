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

    private void OnEnable()
    {
        EventManager.OnItemFallEvent += ChangeCount;
    }

    private void OnDisable()
    {
        EventManager.OnItemFallEvent -= ChangeCount;
        
    }

    private void OnTriggerEnter(Collider other)
    {
       // ChangeCount(other);
        pool.ReturnToPool(other.GetComponent<PooledObject>());
    }

    private void ChangeCount(string tag)
    {
        foreach (var counter in counterCreator.RequestedCounters)
        {
            if (tag.Equals(counter.Name))
            {
                counter.IncrementCount();
            }
        }
        EventManager.CountChangedEvent();
    }
}

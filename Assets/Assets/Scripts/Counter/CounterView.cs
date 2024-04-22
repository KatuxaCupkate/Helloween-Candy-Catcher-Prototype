using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class CounterView : MonoBehaviour
{
    [SerializeField] Text[] _countersTexts;
    [SerializeField] Text[] _countersCounts;
    private List<Counter> _setCounters;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
       EventManager.OnCountersSetEvent+=SetCountersView;
        EventManager.OnCountChangedEvent += ChangeView;
    }
    private void OnDisable()
    {
         EventManager.OnCountersSetEvent-=SetCountersView;
        EventManager.OnCountChangedEvent -= ChangeView;
        
    }
    private void SetCountersView(List<Counter> counters)
    {
        for (int i = 0; i < _countersTexts.Length; i++)
        {
            var counter = counters[i];
            _countersTexts[i].text = " " + counter.Name;
            _countersCounts[i].text = counter.Count.ToString();
            _setCounters = counters;
        }
    }
   
    private void ChangeView()
    {
        for (int i = 0; i < _countersCounts.Length; i++)
        {
            _countersCounts[i].text = _setCounters[i].Count.ToString();
            
        }
    }
}

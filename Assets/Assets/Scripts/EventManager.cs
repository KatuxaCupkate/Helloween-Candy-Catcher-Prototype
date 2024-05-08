using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager 
{
    public static  Action<Dictionary<GameObject, int>> OnRequirementsSetEvent;
    public static Action OnRemoveRequirementsEvent; 
    public static Action<List<Counter>> OnCountersSetEvent;
    public static Action OnCountChangedEvent;

    public static Action<string> OnItemFallEvent;

    public static void RequirementsSetEvent(Dictionary<GameObject, int> placedCandies)
    {
        OnRequirementsSetEvent?.Invoke(placedCandies);
    }
    public static void RequirementsRemovedEvent()
    {
        OnRemoveRequirementsEvent?.Invoke();
    }
    public static void CountersSetEvent(List<Counter> counters)
    {
        OnCountersSetEvent?.Invoke(counters);
    }

    public static void CountChangedEvent() 
    {
      OnCountChangedEvent?.Invoke();
    }

    public static void ItemFallEvent(string ItemTag)
    {
        OnItemFallEvent?.Invoke(ItemTag);
    }
}

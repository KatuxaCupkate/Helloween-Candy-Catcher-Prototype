using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class  Counter
{
    public int Count { get; private set; }
    public string Name { get; private set; }
    public Counter(string _objName)
    {
        Count = 0;
        Name = _objName;
    }
   

   public void IncrementCount()
    {
       Count++;
    }

   public void ResetCounter()
    {
        Count = 0;
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
   
   [SerializeField] private List <Transform> spawnTransformList;

   [SerializeField, Range (1f,5f)]private float _spawnRate;
   
   [SerializeField] List <ObjectPool> poolsList;

 
  
    private void Start()
    {
      
    }

    public void SpawnTarget()
    {
        StartCoroutine(SpawnQueue());
    }

   private IEnumerator SpawnQueue()
    {
        for (int i = 0;i<= spawnTransformList.Capacity-1;i++)
        {
            poolsList[GetRandomCandyIndex()].GetPooledObject().transform.position = spawnTransformList[i].position;
            yield return new WaitForSeconds(_spawnRate);
        }
    }

    private int GetRandomCandyIndex()
    {
        var index = Random.Range(0, poolsList.Count);
        return index;
    }

}

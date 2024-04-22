using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{ 
    [SerializeField] private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager=FindAnyObjectByType<SpawnManager>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.K))
        {
          spawnManager.SpawnTarget();
        }
        
      
    }

}

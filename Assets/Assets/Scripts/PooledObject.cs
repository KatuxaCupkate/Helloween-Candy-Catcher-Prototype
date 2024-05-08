using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PooledObject : MonoBehaviour
{

    public ObjectPool  Pool { get => pool; set => pool = value; }
    private ObjectPool pool;
    
    [SerializeField] private float _minSpeed = 6;
    [SerializeField] private float _maxSpeed = 8;
    [SerializeField] private float _maxTorque = 10;

    private Rigidbody _targetRb;
   
    // Start is called before the first frame update
    void Start()
    {
        _targetRb = GetComponent<Rigidbody>();
   
    }

  
    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.collider.CompareTag("Counter"))
        {   
            Release();
            EventManager.ItemFallEvent(tag);
        }
        else if(collision.collider.CompareTag("Ground"))
        {
            Release();
        }
        
    }
    public Vector3 RandomForсe()
    {
        return new Vector3(1, 1, 0) *_maxSpeed;
    }

    float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }
     

    public void SetCondition(Rigidbody rig) // set condition to pooled objects rigidbody
    {   
        rig.AddForce(RandomForсe(), ForceMode.Impulse);
        rig.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());
    }
    public void ResetCondition(Rigidbody rig)
    {
        rig.velocity = Vector3.zero; 
        rig.angularVelocity = Vector3.zero;
    }
    public void Release()
    {   
        ResetCondition(_targetRb);
        pool.ReturnToPool(this);
         
    }
}

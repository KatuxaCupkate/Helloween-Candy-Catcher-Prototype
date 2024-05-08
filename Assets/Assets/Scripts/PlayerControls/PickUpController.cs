using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [SerializeField] Transform holdArea;
    private GameObject heldObject;
    private Rigidbody heldObjRB;

    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    private float pickupDragRB = 10;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (heldObject==null)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit,pickupRange))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }

        if(heldObject!=null)
        {
            MoveObject();
        }
    }

   private void PickupObject(GameObject pickObject)
    {
        if(pickObject.GetComponent<Rigidbody>())
        {
            heldObjRB = pickObject.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = pickupDragRB;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = holdArea;
            heldObject = pickObject;
        }
    }

    private void DropObject()
    {
        
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;
        heldObject = null;
    }

    private void MoveObject()
    {
        if(Vector3.Distance(heldObject.transform.position, holdArea.position)>0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObject.transform.position);
            heldObjRB.AddForce(moveDirection*pickupForce);
        }
    }
}

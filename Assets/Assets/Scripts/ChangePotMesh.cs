using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangePotMesh : MonoBehaviour
{
    [SerializeField] Mesh meshFull;
    [SerializeField] Mesh meshEmpty;

    private MeshFilter potMeshFilter;
    private Mesh potMesh;

    private void Start()
    {
        potMeshFilter = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ChangeMeshToFull();
        }
    }
    private void ChangeMeshToFull()
    {
        potMeshFilter.sharedMesh = meshFull;
        
    }

    private void ChangeMeshToEmpty()
    {
        potMeshFilter.sharedMesh = meshEmpty;
    }
}

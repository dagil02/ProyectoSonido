using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviso_entrada : MonoBehaviour
{
    public Headsets script;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            script.EnteredBuilding();
        }
    }
}

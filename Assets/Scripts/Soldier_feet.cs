using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_feet : MonoBehaviour
{
    public bool ismoving = false;
    public bool isshouting = false;
    public bool isshooting = false;
    int floor_type = 1; //Stone-0 Grass-1 Earth-2 Wood-3

    void Start()
    {
        InvokeRepeating("ProcessSteps", 0, 0.4f);
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Stone":
                floor_type = 0;
                break;
            case "Grass":
                floor_type = 1;
                break;
            case "Earth":
                floor_type = 2;
                break;
            case "Wood":
                floor_type = 3;
                break;
            default:
                break;
        }
    }
    private void ProcessSteps()
    {
        if (!ismoving) return;

        FMOD.Studio.EventInstance footstep = FMODUnity.RuntimeManager.CreateInstance("event:/Steps/Footsteps");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(footstep, this.transform);
        footstep.setParameterByName("Floor", floor_type);
        footstep.setParameterByName("Speed", 0);
        footstep.start();
        footstep.release();
    }
}

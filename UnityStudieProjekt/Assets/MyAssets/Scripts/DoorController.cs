using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += Current_onDoorwayTriggerEnter;
        GameEvents.current.onDoorwayTriggerExit += Current_onDoorwayTriggerExit;
    }

    private void OnDestroy()
    {
        GameEvents.current.onDoorwayTriggerEnter -= Current_onDoorwayTriggerEnter;
        GameEvents.current.onDoorwayTriggerExit -= Current_onDoorwayTriggerExit;
    }

    private void Current_onDoorwayTriggerEnter()
    {
        // Detta k�rs n�r vi triggar h�ndelsen fr�n n�gonstans
        // Exempelvis l�t oss h�r f�rflytta d�rren upp�t
        this.transform.Translate(0.0f, 6.0f, 0.0f);
    }

    private void Current_onDoorwayTriggerExit()
    {
        // F�rflyttar d�rren ned igen n�r vi tr�der ut
        this.transform.Translate(0.0f, -6.0f, 0.0f);
    }
}

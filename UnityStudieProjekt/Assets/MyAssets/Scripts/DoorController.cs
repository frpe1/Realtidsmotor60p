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
        // Detta körs när vi triggar händelsen från någonstans
        // Exempelvis låt oss här förflytta dörren uppåt
        this.transform.Translate(0.0f, 6.0f, 0.0f);
    }

    private void Current_onDoorwayTriggerExit()
    {
        // Förflyttar dörren ned igen när vi träder ut
        this.transform.Translate(0.0f, -6.0f, 0.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Denna del g�r att vi kopplar ihop "player" med 
            // objektet som detta skript �r knutet till, dvs i detta fall
            // s� var det animatedPlatform. S� Player blir en "child"
            // under AnimatedPlatform.
            other.transform.parent = this.transform;
            //other.gameObject.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Denna del g�r att vi kopplar bort v�rt objekt fr�n
            // detta objekt s� dessa tv� inte �r sammankopplade n�got mer
            other.transform.parent = null;
            //other.gameObject.transform.SetParent(null);
        }
    }
}

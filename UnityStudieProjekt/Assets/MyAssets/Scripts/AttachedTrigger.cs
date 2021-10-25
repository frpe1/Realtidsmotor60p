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
            // Denna del gör att vi kopplar ihop "player" med 
            // objektet som detta skript är knutet till, dvs i detta fall
            // så var det animatedPlatform. Så Player blir en "child"
            // under AnimatedPlatform.
            other.transform.parent = this.transform;
            //other.gameObject.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Denna del gör att vi kopplar bort vårt objekt från
            // detta objekt så dessa två inte är sammankopplade något mer
            other.transform.parent = null;
            //other.gameObject.transform.SetParent(null);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject refToPoint;

    private void OnTriggerEnter(Collider other)
    {
        // H�r kollar vi s� att det bara �r spelaren som tr�der in i triggern
        // annars s� h�nder inget
        if (other.gameObject.CompareTag("Player"))
        {
            // S� h�r g�r man f�r att placera ett objekt p� en viss position med en viss riktning
            other.gameObject.transform.position = refToPoint.transform.position;
            other.gameObject.transform.rotation = Quaternion.identity;
        }
    }
}

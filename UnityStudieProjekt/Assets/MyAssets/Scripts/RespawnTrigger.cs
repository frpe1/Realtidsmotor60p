using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject refToPoint;

    private void OnTriggerEnter(Collider other)
    {
        // Här kollar vi så att det bara är spelaren som träder in i triggern
        // annars så händer inget
        if (other.gameObject.CompareTag("Player"))
        {
            // Så här gör man för att placera ett objekt på en viss position med en viss riktning
            other.gameObject.transform.position = refToPoint.transform.position;
            other.gameObject.transform.rotation = Quaternion.identity;
        }
    }
}

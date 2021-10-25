using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneObject : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabToClone;

    [SerializeField]
    private GameObject respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        // Instantiate "klonar" eller g�r en kopia av ett objekt, i detta fall vad prefabToClone
        // pekar p� och placerar det p� positionen som respawnPoint befinner sig vid.
        // Quaternion har bara med rotationsaxlarna att g�ra och h�r anv�nder vi "identity" 
        // f�r att nollst�lla rotationsriktningen f�r det objektet vi klonade
        Instantiate(prefabToClone, respawnPoint.transform.position, Quaternion.identity);
    }
}

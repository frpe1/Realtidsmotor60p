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
        // Instantiate "klonar" eller gör en kopia av ett objekt, i detta fall vad prefabToClone
        // pekar på och placerar det på positionen som respawnPoint befinner sig vid.
        // Quaternion har bara med rotationsaxlarna att göra och här använder vi "identity" 
        // för att nollställa rotationsriktningen för det objektet vi klonade
        Instantiate(prefabToClone, respawnPoint.transform.position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLight : MonoBehaviour
{
    [SerializeField]
    private GameObject refToLight;

    private bool isEnabled;

    private void Start()
    {
        isEnabled = false;  // starta alltid med att detta objekt är "avaktiverad"
        refToLight.SetActive(isEnabled); // SetActive aktiverar eller avaktiverar objekt beroende på om värdet är true eller false
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // växla från inaktiv till aktiv eller vice versa
        // varje gång vi stiger in i denna triggers
        isEnabled = !isEnabled;

        // Denna metod till gameobject aktiverar / deaktiverar objektet
        refToLight.SetActive(isEnabled);
    }
}

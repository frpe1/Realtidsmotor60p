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
        isEnabled = false;  // starta alltid med att detta objekt �r "avaktiverad"
        refToLight.SetActive(isEnabled); // SetActive aktiverar eller avaktiverar objekt beroende p� om v�rdet �r true eller false
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // v�xla fr�n inaktiv till aktiv eller vice versa
        // varje g�ng vi stiger in i denna triggers
        isEnabled = !isEnabled;

        // Denna metod till gameobject aktiverar / deaktiverar objektet
        refToLight.SetActive(isEnabled);
    }
}

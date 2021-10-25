using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField]
    private GameObject refToTargetToChangeMaterial;

    private Renderer _material;

    private void Start()
    {
        // GetComponent har som syfte att h�mta komponenten fr�n detta objekt som detta skript �r bundet till
        // (och i detta fall just komponenten Renderer)
        // och spara den i _material s� vi kan komma �t denna komponent i OnTriggerEnter.
        _material = refToTargetToChangeMaterial.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detta �ndrar f�rgen p� ett material 
        _material.material.SetColor("_Color", Color.red);
    }
}

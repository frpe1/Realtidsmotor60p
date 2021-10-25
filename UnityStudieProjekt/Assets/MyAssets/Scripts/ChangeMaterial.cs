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
        // GetComponent har som syfte att hämta komponenten från detta objekt som detta skript är bundet till
        // (och i detta fall just komponenten Renderer)
        // och spara den i _material så vi kan komma åt denna komponent i OnTriggerEnter.
        _material = refToTargetToChangeMaterial.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detta ändrar färgen på ett material 
        _material.material.SetColor("_Color", Color.red);
    }
}

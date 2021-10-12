using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherScript : MonoBehaviour
{
    public Variables referenceToAnotherScript;

    // Start is called before the first frame update
    void Start()
    {
        referenceToAnotherScript.numberOfCars = 1000;

        Debug.Log("AnotherScript : " + referenceToAnotherScript.numberOfCars);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

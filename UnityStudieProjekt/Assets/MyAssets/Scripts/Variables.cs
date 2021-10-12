using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public int numberOfCars;

    private int newNumberOfCars;

    Transform anotherGameObject;

    // Start is called before the first frame update
    void Start()
    {
        

        // numberOfCars = 10;

        //Debug.Log(numberOfCars);

        newNumberOfCars = numberOfCars + 200;


        Debug.Log("Variables: " + newNumberOfCars);

        // transform.Translate(1, 2, 3);

        

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(numberOfCars);
        // Debug.Log(newNumberOfCars);
        /*

        newNumberOfCars = newNumberOfCars + 10;

        if (newNumberOfCars > 300)
        {
            Debug.Log("Du har nått max antal bilar nu!");
        }
        */
    }
}

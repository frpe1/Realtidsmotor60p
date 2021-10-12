using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Hello : this happens only once in the beginning");

        Debug.Log("This is second message");

        // ?ndrar namnet p? kubobjektet
        transform.name = "SUPERCUBE";

        transform.position = new Vector3(5.0f, 0.0f, 0.0f);

        //transform.Translate(5.0f, 0.0f, 0.0f);

        transform.Translate(1.0f, 0.0f, 0.0f);

        transform.Rotate(0, 45, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //  transform.position = new Vector3(5.0f, 0.0f, 0.0f);

        // transform.Translate(0.01f, 0.0f, 0.0f);

        // Denna kommando skrivs ut varje frame per sekund
        // Debug.Log("This happens every FPS");

        // Debug.Log("Hello World");

        /*
         
        if ( .....villkor..... ) { 
            ........ 
        } else { 
            .......
        }

        */

        // Detta ?r s?ttet f?r att l?sa av tagentbordstryckningen "space"
        if ( Input.GetKeyDown(KeyCode.Space) ) {
            Debug.Log("Du tryckte ned space tagenten");
        }
    }


    /*
    void myFunction() { 
        
    }

    */
}

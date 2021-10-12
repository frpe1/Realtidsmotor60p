using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    float x;
    float y;
    float z;

    // Ovan kan typ även deklareras på följande sätt
    // float x, y, z;


    // Start is called before the first frame update
    void Start()
    {
        x = 2.0f;
        y = 2.0f;
        z = 5.0f;

        // Så kan vi använda oss av variabler
        transform.Translate(x, y, z);

        // transform.Translate(2.0f, 2.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            x = 1.0f;
            y = 0.0f;
            z = 0.0f;
            transform.Translate(x, y, z);

            // här är ett annat trevligt sammanfattande sätt
            // vi kan uttrycka ovan på
            Vector3 move = new Vector3(1.0f, 0.0f, 0.0f);

            transform.Translate(move);

            // tredje sätt X-D
            // transform.position = new Vector3(1.0f, 0.0f, 0.0f);
        }
    }
}

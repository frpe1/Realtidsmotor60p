using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    Rigidbody boxForce;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello Box");
        // transform.position = new Vector3(5, 0.5, 0);
        boxForce = gameObject.GetComponent<Rigidbody>();

        

        if (!boxForce)
            Debug.Log("RigidBody Doesn't exist");

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0));
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            boxForce.AddForce(10, 0, 0);
    }
}

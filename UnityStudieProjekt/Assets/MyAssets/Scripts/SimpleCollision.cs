using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ENTER: This object has collided with : " + collision.gameObject.tag);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("EXIT: This object is exiting the collision with : " + collision.gameObject.tag);
    }
}

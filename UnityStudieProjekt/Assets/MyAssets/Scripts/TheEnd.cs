using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Start körs en gång!"); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Debug.Log("You're not allowed to end the game");

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You have reach the end of the game");
        }
    }

    private void Update()
    {
        transform.Translate(0, 0, 5.0f * Time.deltaTime);
    }
}

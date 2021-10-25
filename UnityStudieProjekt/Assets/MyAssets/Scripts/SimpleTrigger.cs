using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrigger : MonoBehaviour
{
    // Detta sker n�r vi "tr�der in" i triggern f�rsta g�ngen
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER: You have step into the simple trigger");

        // Vi kan anv�nda oss av collision.gameobject.tag f�r att avl�sa
        // VEM som precis d� gick in i triggern.
        // sedan p� det kan vi url�sa med en IF sats OM det var spelaren, d� kanske vi vill g�ra n�got!
        /*
        if (other.gameObject.CompareTag("Player"))
        {
            // H�r kan ni skriva n�gto som intr�ffar om det var just spelaren sj�lv
        }
        */
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    // Detta sker n�r vi "tr�der ut" fr�n triggern sist
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("EXIT: You have step out from the simple trigger");
    }
}






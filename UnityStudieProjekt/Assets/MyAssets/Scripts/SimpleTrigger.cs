using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrigger : MonoBehaviour
{
    // Detta sker när vi "träder in" i triggern första gången
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER: You have step into the simple trigger");

        // Vi kan använda oss av collision.gameobject.tag för att avläsa
        // VEM som precis då gick in i triggern.
        // sedan på det kan vi urläsa med en IF sats OM det var spelaren, då kanske vi vill göra något!
        /*
        if (other.gameObject.CompareTag("Player"))
        {
            // Här kan ni skriva någto som inträffar om det var just spelaren själv
        }
        */
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    // Detta sker när vi "träder ut" från triggern sist
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("EXIT: You have step out from the simple trigger");
    }
}






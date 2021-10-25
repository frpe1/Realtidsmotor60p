using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactivateComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject refToObject;

    private Rigidbody rb;

    private bool isEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = refToObject.GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("This object does not have RigidBody component");
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isEnabled = !isEnabled;

        // Detta s�tter fysikens p�verkan p� kuben 
        // dvs om den tempor�rt inte ska fungera eller om den ska vara aktiverad
        // rb.isKinematic = isEnabled;

        // RigidBody har inte "enabled" men 
        // f�r vissa komponenter r�cker avaktivera med hj�lp av variabeln "enabled"
        // som finns f�r m�nga av dessa.
        // exempelvis
        //GetComponent<Renderer>().enabled = isEnabled;

        // Detta tar bort detta skript som �r knutet till objektet
        // Destroy(this);

        // Detta tar bort RigidBody f�r objektet som hade den komponenten
        Destroy(rb);

    }

}

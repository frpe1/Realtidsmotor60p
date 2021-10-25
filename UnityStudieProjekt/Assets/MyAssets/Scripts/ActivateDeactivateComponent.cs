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

        // Detta sätter fysikens påverkan på kuben 
        // dvs om den temporärt inte ska fungera eller om den ska vara aktiverad
        // rb.isKinematic = isEnabled;

        // RigidBody har inte "enabled" men 
        // för vissa komponenter räcker avaktivera med hjälp av variabeln "enabled"
        // som finns för många av dessa.
        // exempelvis
        //GetComponent<Renderer>().enabled = isEnabled;

        // Detta tar bort detta skript som är knutet till objektet
        // Destroy(this);

        // Detta tar bort RigidBody för objektet som hade den komponenten
        Destroy(rb);

    }

}

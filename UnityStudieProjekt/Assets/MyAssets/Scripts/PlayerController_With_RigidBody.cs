using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Denna klass för att styra playerkontroller använder RigidBody
/// och därmed kan vi använda krafter för att styra vår player med.
public class PlayerController_With_RigidBody : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private GroundCheck groundCheck;

    private Rigidbody playerBody;

    private Vector3 movement;
    private Vector3 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();

        if (playerBody == null)
        {
            Debug.LogError("You missing RigidBody in order to make it work!");
            return;
        }
    }

    bool isGrounded = true;

    // Update is called once per frame
    void Update()
    { 
        // Exempel 1) här hoppar vi uppåt när vi trycker ned space-tagenten
        // Vi använder oss av här AddForce vilket är en metod som finns tillgänglig
        // så fort vi lägger till "RigidBody". AddForce påverkar vårt objekt med en s.k. "Kraft"
        // i någon riktning och här påverkar den längs y-axeln dvs uppåt
        // Så här är vårt första försök till "jump"
       
       
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        movement = new Vector3(xMovement, 0.0f, zMovement);

        transform.Translate(movement * speed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("jump");
            isGrounded = false;
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        
        // Exempel 2) Här använder vi Force för att accelerera vår karaktär
        // 
       /*
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        movement = new Vector3(0, 0, zMovement);

        // If-satsen här säger att vi endast förflyttar om vi hade tryckt
        // ned någon tagenttryckning ovan. 
        if (movement != Vector3.zero)
            playerBody.AddForce(movement * Time.deltaTime, ForceMode.Impulse);
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground") && !isGrounded)
        {
            isGrounded = true;
        }

        // Ytterligare sak:
        // if (collision.gameObject.layer == LayerMask.GetMask(""))
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_With_CharacterController : MonoBehaviour
{
    [SerializeField]
    private float speed;    
    
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float jumpSpeed;

    private float gravity = 9.82f;

    private bool isGrounded = true;

    private CharacterController charController;

    private float originalStepOffset;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        if (!charController)
        {
            Debug.LogError("You missing the character controller component");
            return;
        }

        originalStepOffset = charController.stepOffset;

    }

    // Update is called once per frame
    void Update()
    {
        // Exempel 1) Vi visar hur man förflyttar med character controller
        /*
        float rotY = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(0, 0, moveZ);

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        // här är characters kommando för förflyttning
        charController.Move(moveDirection);

        // Beräkna lite hastigheten för rotationen
        rotY = rotY * rotationSpeed * Time.deltaTime;

        // Utför själva rotationen
        transform.Rotate(0, rotY, 0);
        */


        // Exempel 2) Här tar vi även med "Jump"

        /*
        float rotY = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(0, 0, moveZ);

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        /// NEW ///
        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed * Time.deltaTime;
        }

        // här utför vi vår egna simulerande gravitationsberäkning
        moveDirection.y -= gravity * Time.deltaTime;

        /// NEW ///

        // här är characters kommando för förflyttning
        charController.Move(moveDirection);

        // Beräkna lite hastigheten för rotationen
        rotY = rotY * rotationSpeed * Time.deltaTime;

        // Utför själva rotationen
        transform.Rotate(0, rotY, 0);
        
        */

        // Exempel 3) Här är ett annat sätt att förflytta vår karaktär
        // med character controller som också tar hänsyn till att vi INTE
        // kan hålla ned knapptryckningen för jump och fortsätta uppåt
        // utan vi kan bara trycka ned knappen en gång. Vi använder 
        // sedan isGrounded för att säkra att vi hoppar från marken
        // sedan OnColliderEnter för att nollställa isGrounded när vi landar igen.

        float rotY = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(0, 0, moveZ);

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        /// NEW ///
        if (Input.GetButtonDown("Jump") && charController.isGrounded)
        {
            isGrounded = false;
            moveDirection.y = jumpSpeed * Time.deltaTime;
        }

        // här utför vi vår egna simulerande gravitationsberäkning
        moveDirection.y -= gravity * Time.deltaTime;

        /// NEW ///

        // här är characters kommando för förflyttning
        charController.Move(moveDirection);

        // Beräkna lite hastigheten för rotationen
        rotY = rotY * rotationSpeed * Time.deltaTime;

        // Utför själva rotationen
        transform.Rotate(0, rotY, 0);

    }

    /*
    // Yek! ingen bra lösning, uppdateras varje flera gånger per sekund
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.tag);
        if (hit.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Hit the ground!");
            isGrounded = true;
        }
    }
    */


}

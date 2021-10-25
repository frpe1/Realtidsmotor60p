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
        // Exempel 1) Vi visar hur man f�rflyttar med character controller
        /*
        float rotY = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(0, 0, moveZ);

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        // h�r �r characters kommando f�r f�rflyttning
        charController.Move(moveDirection);

        // Ber�kna lite hastigheten f�r rotationen
        rotY = rotY * rotationSpeed * Time.deltaTime;

        // Utf�r sj�lva rotationen
        transform.Rotate(0, rotY, 0);
        */


        // Exempel 2) H�r tar vi �ven med "Jump"

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

        // h�r utf�r vi v�r egna simulerande gravitationsber�kning
        moveDirection.y -= gravity * Time.deltaTime;

        /// NEW ///

        // h�r �r characters kommando f�r f�rflyttning
        charController.Move(moveDirection);

        // Ber�kna lite hastigheten f�r rotationen
        rotY = rotY * rotationSpeed * Time.deltaTime;

        // Utf�r sj�lva rotationen
        transform.Rotate(0, rotY, 0);
        
        */

        // Exempel 3) H�r �r ett annat s�tt att f�rflytta v�r karakt�r
        // med character controller som ocks� tar h�nsyn till att vi INTE
        // kan h�lla ned knapptryckningen f�r jump och forts�tta upp�t
        // utan vi kan bara trycka ned knappen en g�ng. Vi anv�nder 
        // sedan isGrounded f�r att s�kra att vi hoppar fr�n marken
        // sedan OnColliderEnter f�r att nollst�lla isGrounded n�r vi landar igen.

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

        // h�r utf�r vi v�r egna simulerande gravitationsber�kning
        moveDirection.y -= gravity * Time.deltaTime;

        /// NEW ///

        // h�r �r characters kommando f�r f�rflyttning
        charController.Move(moveDirection);

        // Ber�kna lite hastigheten f�r rotationen
        rotY = rotY * rotationSpeed * Time.deltaTime;

        // Utf�r sj�lva rotationen
        transform.Rotate(0, rotY, 0);

    }

    /*
    // Yek! ingen bra l�sning, uppdateras varje flera g�nger per sekund
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

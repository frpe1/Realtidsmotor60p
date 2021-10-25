using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
    // Anv�nds mellan Exempel 2 - 5 endast
    [SerializeField]
    float speed;
    */

    // Anv�nds till Exempel 6, 8, 9, vi lade �ven till Range f�r att begr�nsa intervallet i editorn
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10;
   
    // Anv�nds fr�n Exempel 7, 8
    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10;

    // Anv�nds f�r Exempel 9, f�r hastigheten p� rotationen
    [SerializeField]
    float rotationSpeed = 7.0f;

    // Anv�nds fr�n Exempel 7, beskriver den nuvarande hastigheten
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        // speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        ///////////////////////// F�RFLYTTNING ////////////////////
        ///
        // Exempel 0), Absolut enklast animering f�rflyttar med fixa v�rdet 1.0f varje g�ng
        //transform.Translate(0.0f, 0.0f, 1.0f);

        // Exempel 1, f�rflyttar mjukt
        //transform.Translate(0.0f, 0.0f, 1.0f * Time.deltaTime);

        // Exempel 2), f�rflyttar mjuk men kontrollerar hastigheten via variabeln "speed"
        // Samt anv�nder vector3 som vi kallar "movement"
        //Vector3 movement = new Vector3(0.0f, 0.0f, speed * Time.deltaTime);
        //transform.Translate(movement);

        // Exempel 3), f�rflytta fortfarande mjukare med kontrollerna A och D
        /*
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, speed * Time.deltaTime);
            transform.Translate(movement);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 velocity = new Vector3(0.0f, 0.0f, -speed * Time.deltaTime);
            transform.Translate(velocity);
        }
        */

        // Exempel 4) som exempel 3, fast h�r anv�nder vi den mer generella
        // Horizontal och Vertical f�r f�rflytta med tagentborden W,A,S,D p� en g�ng ist�llet
        // och returnerar ist�llet ett v�rde l�ngs X och Y axeln. 
        // Och vi kan ta bort v�ra "if satser" f�r l�sa av dessa och sedan baka in
        // v�r interaktion direkt i v�r "movement" vektor
        /*
        Vector3 playerInput;

        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.z = Input.GetAxis("Vertical");
       
        Vector3 movement = new Vector3(playerInput.x * speed * Time.deltaTime, 0.0f, playerInput.z * speed * Time.deltaTime);
        transform.Translate(movement);
        */

        // Exempel 5) H�r �r ett annat s�tt att "f�rflytta" sig p� som bygger p� att man sj�lv
        // ber�knar positionen baserat p� v�r realtive f�rflyttning
        // d�r vi kontrollerar hastigheten via "speed"
        // Vi anv�nder ocks� oss av localPosition h�r f�r att f�rflytta ist�llet f�r Translate
        // localPosition ger m�jligheten att vi kan f�rflytta "lokalt" l�ngs ett parent objekt
        /*
        Vector3 playerInput;

        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.z = Input.GetAxis("Vertical");
        
        // Notera:
        // float s = speed * Time.deltaTime;
        // float dx = playerInput.x * s;
        // float dz = playerInput.z * s;
        // Vector3 movement = new Vector3(dx, 0.0f, dz);
        // �r identiskt med nedan skrivs�tt
        Vector3 movement = new Vector3(playerInput.x * speed * Time.deltaTime, 0.0f, playerInput.z * speed * Time.deltaTime);

        // Notera:  
        // transform.localPosition = transform.localPosition + movement;
        // �r identiskt med nedan skrivs�tt
        transform.localPosition += movement;

        */

        // Exempel 6) Vi skriver om det d�r med "hastigheten" lite s� vi anv�nder 
        // termen "velocity" ist�llet. Exempel 5b �r identisk med exempel 5, men vi 
        // vill p� n�got s�tt bryta ut hastigeten h�r, Vi �ndrar ocks� namnet p� speed
        // till "maxSpeed" vilket verkar mer vettigare i sammanhanget
        /*
        Vector3 playerInput;

        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.z = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(playerInput.x , 0.0f, playerInput.z) * maxSpeed;
        Vector3 movement = velocity * Time.deltaTime;
        transform.localPosition += movement;
        */

        // Exempel 7)
        // Accelerationen �r ocks� n�got vi kan f� in i v�ra ber�kningar.
        // f�r att g�ra det s� m�ste vi �ven se till att "velocity" ist�llet blir en "global" variabel
        // S� dessa kodrader nedan g�r att vi kontrollerar accelerationen ist�llet
        // och l�ter v�r karakt�r "�ka" snabbare och snabbare i f�renklad mening.
        /*
        Vector3 playerInput;

        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.z = Input.GetAxis("Vertical");

        Vector3 acceleration = new Vector3(playerInput.x, 0.0f, playerInput.z) * maxAcceleration;
        velocity += acceleration * Time.deltaTime;  // OBS detta f�ljer r�relseformeln v = v0 + a * t
        Vector3 movement = velocity * Time.deltaTime;
        
        transform.localPosition += movement;
        */

        // Exempel 8) Detta tar med b�de maxSpeed och maxAccelerationen, vilket kan tolkas
        // som att har man st�rre maxAccelertation s� kommer man snabbare upp till v�r maxSpeed
        // och har man l�gre v�rde kommer man l�ngsammare upp till sin max hastighet.
        // max hastigheten (maxSpeed) var ju det som s�tter "gr�nsen" f�r hur fort vi f�r r�ra oss
        // S� h�r kan man s�ga att vi f�tt in "smooth" och "damping" i r�relsen
       /*
        Vector3 playerInput;

        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.z = Input.GetAxis("Vertical");

        Vector3 desiredVelocity = new Vector3(playerInput.x, 0, playerInput.z) * maxSpeed;

        float maxSpeedChange = maxAcceleration * Time.deltaTime;

        if (velocity.x < desiredVelocity.x)
        {
            velocity.x = Mathf.Min(velocity.x + maxSpeedChange, desiredVelocity.x);
        } else if (velocity.x > desiredVelocity.x)
        {
            velocity.x = Mathf.Max(velocity.x - maxSpeedChange, desiredVelocity.x);
        }

        if (velocity.z < desiredVelocity.z)
        {
            velocity.z = Mathf.Min(velocity.z + maxSpeedChange, desiredVelocity.z);
        }
        else if (velocity.z > desiredVelocity.z)
        {
            velocity.z = Mathf.Max(velocity.z - maxSpeedChange, desiredVelocity.z);
        }

        Vector3 movement = velocity * Time.deltaTime;

        transform.localPosition += movement;
       
        */
        ///////////////////////// F�RFLYTTNING MED ROTATIONER ////////////////////

        // Exempel 9) H�r tar vi nu med rotationer f�r rotering av v�r "player"
        // och vi anv�nder oss av Horizontal f�r GetAxis f�r att l�sa av rotationen 
        // ist�llet f�r som tidigare f�rflyttningen.
        // MEN notera ocks� n�got mycket viktigt h�r. Vi betraktar i och med att vi
        // nu f�r rotationen att z-axeln nu �r synonymt med v�r s.k. "look-direction"
        // med hj�lp av rotering kring y-axeln s� kommer z-axeln peka �t olika h�ll

        
        float rotateY = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        rotateY = rotateY * rotationSpeed * Time.deltaTime; 
        moveZ = moveZ * maxSpeed * Time.deltaTime;

        // Denna del f�rflyttar oss l�ngs z-axeln
        transform.Translate(0, 0, moveZ);

        // Denna del roterar kring y-axeln
        transform.Rotate(0, rotateY, 0);
        

    }
}

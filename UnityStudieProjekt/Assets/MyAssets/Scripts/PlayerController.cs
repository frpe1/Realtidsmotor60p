using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
    // Används mellan Exempel 2 - 5 endast
    [SerializeField]
    float speed;
    */

    // Används till Exempel 6, 8, 9, vi lade även till Range för att begränsa intervallet i editorn
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10;
   
    // Används från Exempel 7, 8
    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10;

    // Används för Exempel 9, för hastigheten på rotationen
    [SerializeField]
    float rotationSpeed = 7.0f;

    // Används från Exempel 7, beskriver den nuvarande hastigheten
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        // speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        ///////////////////////// FÖRFLYTTNING ////////////////////
        ///
        // Exempel 0), Absolut enklast animering förflyttar med fixa värdet 1.0f varje gång
        //transform.Translate(0.0f, 0.0f, 1.0f);

        // Exempel 1, förflyttar mjukt
        //transform.Translate(0.0f, 0.0f, 1.0f * Time.deltaTime);

        // Exempel 2), förflyttar mjuk men kontrollerar hastigheten via variabeln "speed"
        // Samt använder vector3 som vi kallar "movement"
        //Vector3 movement = new Vector3(0.0f, 0.0f, speed * Time.deltaTime);
        //transform.Translate(movement);

        // Exempel 3), förflytta fortfarande mjukare med kontrollerna A och D
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

        // Exempel 4) som exempel 3, fast här använder vi den mer generella
        // Horizontal och Vertical för förflytta med tagentborden W,A,S,D på en gång istället
        // och returnerar istället ett värde längs X och Y axeln. 
        // Och vi kan ta bort våra "if satser" för läsa av dessa och sedan baka in
        // vår interaktion direkt i vår "movement" vektor
        /*
        Vector3 playerInput;

        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.z = Input.GetAxis("Vertical");
       
        Vector3 movement = new Vector3(playerInput.x * speed * Time.deltaTime, 0.0f, playerInput.z * speed * Time.deltaTime);
        transform.Translate(movement);
        */

        // Exempel 5) Här är ett annat sätt att "förflytta" sig på som bygger på att man själv
        // beräknar positionen baserat på vår realtive förflyttning
        // där vi kontrollerar hastigheten via "speed"
        // Vi använder också oss av localPosition här för att förflytta istället för Translate
        // localPosition ger möjligheten att vi kan förflytta "lokalt" längs ett parent objekt
        /*
        Vector3 playerInput;

        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.z = Input.GetAxis("Vertical");
        
        // Notera:
        // float s = speed * Time.deltaTime;
        // float dx = playerInput.x * s;
        // float dz = playerInput.z * s;
        // Vector3 movement = new Vector3(dx, 0.0f, dz);
        // är identiskt med nedan skrivsätt
        Vector3 movement = new Vector3(playerInput.x * speed * Time.deltaTime, 0.0f, playerInput.z * speed * Time.deltaTime);

        // Notera:  
        // transform.localPosition = transform.localPosition + movement;
        // är identiskt med nedan skrivsätt
        transform.localPosition += movement;

        */

        // Exempel 6) Vi skriver om det där med "hastigheten" lite så vi använder 
        // termen "velocity" istället. Exempel 5b är identisk med exempel 5, men vi 
        // vill på något sätt bryta ut hastigeten här, Vi ändrar också namnet på speed
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
        // Accelerationen är också något vi kan få in i våra beräkningar.
        // för att göra det så måste vi även se till att "velocity" istället blir en "global" variabel
        // Så dessa kodrader nedan gör att vi kontrollerar accelerationen istället
        // och låter vår karaktär "åka" snabbare och snabbare i förenklad mening.
        /*
        Vector3 playerInput;

        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.z = Input.GetAxis("Vertical");

        Vector3 acceleration = new Vector3(playerInput.x, 0.0f, playerInput.z) * maxAcceleration;
        velocity += acceleration * Time.deltaTime;  // OBS detta följer rörelseformeln v = v0 + a * t
        Vector3 movement = velocity * Time.deltaTime;
        
        transform.localPosition += movement;
        */

        // Exempel 8) Detta tar med både maxSpeed och maxAccelerationen, vilket kan tolkas
        // som att har man större maxAccelertation så kommer man snabbare upp till vår maxSpeed
        // och har man lägre värde kommer man långsammare upp till sin max hastighet.
        // max hastigheten (maxSpeed) var ju det som sätter "gränsen" för hur fort vi får röra oss
        // Så här kan man säga att vi fått in "smooth" och "damping" i rörelsen
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
        ///////////////////////// FÖRFLYTTNING MED ROTATIONER ////////////////////

        // Exempel 9) Här tar vi nu med rotationer för rotering av vår "player"
        // och vi använder oss av Horizontal för GetAxis för att läsa av rotationen 
        // istället för som tidigare förflyttningen.
        // MEN notera också något mycket viktigt här. Vi betraktar i och med att vi
        // nu för rotationen att z-axeln nu är synonymt med vår s.k. "look-direction"
        // med hjälp av rotering kring y-axeln så kommer z-axeln peka åt olika håll

        
        float rotateY = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        rotateY = rotateY * rotationSpeed * Time.deltaTime; 
        moveZ = moveZ * maxSpeed * Time.deltaTime;

        // Denna del förflyttar oss längs z-axeln
        transform.Translate(0, 0, moveZ);

        // Denna del roterar kring y-axeln
        transform.Rotate(0, rotateY, 0);
        

    }
}

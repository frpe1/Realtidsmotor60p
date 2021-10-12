using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing2 : MonoBehaviour
{
    // Deklarerar en variabel. 
    int t;
    float a;
    string message;

    // Start is called before the first frame update
    void Start()
    {
        // Tilldela
        t = 0;

        // Skriver ut värdet på t
        Debug.Log("Startvärdet på t : " + t);

        // flyttal, notera att vi lägger till "f" i slutet
        // på s.k. flyttalen och notera även
        // att vi skriver ett decimaltal här
        a = -2.0984f;

        // Med strängar så måste vi använder tecknet " "
        // som omsluter teckena däremellan.
        message = "hej jag heter Fredrik 12801289040129";

        // Vi kan med strängar lägga ihop flera s.k strängar
        string sentence = message + " jag hoppas ni gillar dagens lektion.";

        Debug.Log(sentence);

    }

    // Update is called once per frame
    void Update()
    {
        // tar värdet på "t" och plussar på värdet 1 och spar
        // detta värde åter till "t"
        t = t + 1;

        // överkurs: men denna del gör exakt som ovan
        //t++;
        Debug.Log("Nya värde på t : " + t);


        /*
        if ( ...villkoret... )
        {
            ....detta händer när villkoret är sant....
        } else
        {
            .... detta händer när villkoret INTE är sant....
        }
        */

        // Här läser vi av ett "villkor"
        // där vi testar OM t är större eller lika med värdet 10
        // då ska vi nollställa värdet på t
        if ( t >= 10)
        {
            t = 0;
        }

    }
}

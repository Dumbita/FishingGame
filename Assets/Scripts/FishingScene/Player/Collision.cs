using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public static float count;
    public static float contaminated;

    void Start()
    {

        count = 0;
        contaminated = 0;

    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "FishRed" || collision.gameObject.tag == "FishGreen")
        {

            if (count < 100)
            {

                Destroy(collision.gameObject);

                count++;

                if(collision.gameObject.tag == "FishRed")
                {

                    contaminated++;

                }

            }

        }

    }

}

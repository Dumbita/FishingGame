using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public static float count;
    public static float contaminated;

    public AudioSource catching;
    public AudioClip[] identity = new AudioClip[2];

    void Start()
    {

        count = 0;
        contaminated = 0;

        catching.volume = 0.3f;

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

                    catching.PlayOneShot(identity[1]);

                }
                else if (collision.gameObject.tag == "FishGreen")
                {

                    catching.PlayOneShot(identity[0]);

                }

            }

        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{

    public static float count;
    public static float contaminated;

    public AudioSource catching;
    public AudioClip[] identity = new AudioClip[2];

    public Image glowing;

    void Start()
    {

        count = 0;
        contaminated = 0;

        catching.volume = 0.3f;

        glowing.enabled = false;

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

                    glowing.color= new Color32(243,22,22,56);

                    StartCoroutine(Glow());

                }
                else if (collision.gameObject.tag == "FishGreen")
                {

                    catching.PlayOneShot(identity[0]);

                    glowing.color = new Color32(60,241,26,56);

                    StartCoroutine(Glow());

                }

            }

        }

    }
    IEnumerator Glow()
    {

        glowing.enabled = true;

        yield return new WaitForSeconds(0.2f);

        glowing.enabled = false;

    }

}

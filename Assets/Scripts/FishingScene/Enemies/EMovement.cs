using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMovement : MonoBehaviour
{

    public Sprite[] visual = new Sprite[2];
    BoxCollider2D boundaries;

    Vector2 screenBounds;
    Rigidbody2D fish;

    private SpriteRenderer basic;

    public ScreenBounds screen;
    // setting the trash of fish to go
    void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        basic= GetComponent<SpriteRenderer>();

        fish = GetComponent<Rigidbody2D>();

        screen = FindObjectOfType<ScreenBounds>();

        boundaries= GetComponent<BoxCollider2D>();

        EnemySpawning();

        if (transform.position.x == screenBounds.x -2)
        {

            Left();

        }
        else if (transform.position.x == -screenBounds.x +2)
        {

            Right();

        }

    }
    //movement
    private void Left()
    {

        fish.velocity = new Vector2(-10,0);

        if(gameObject.tag == "FishGreen")
        {

            transform.localScale = new Vector2(0.05f, 0.05f);

        }
     
    }
    private void Right()
    {

        fish.velocity = new Vector2(10, 0);

        if (gameObject.tag == "FishGreen")
        {

            transform.localScale = new Vector2(-0.05f, 0.05f);

        }

    }
    //chance of being trash of a fish
    private void EnemySpawning()
    {

        int chance = Random.Range(0, 100);

        if (chance > 40)
        {

            basic.sprite = visual[0];

            boundaries.size = new Vector2(64f,20f);

            gameObject.tag = "FishGreen";

        }
        else if (chance < 60)
        {

            basic.sprite = visual[1];

            transform.localScale = new Vector2(0.03f, 0.03f);

            boundaries.size = new Vector2(50f, 62f);

            gameObject.tag = "FishRed";

        }

    }
    //sending to the other side of screen
    void Update()
    {

        if (screen.AmIOutOfBounds(transform.position))
        {

            Vector2 newPosition = screen.CalculateWrappedPosition(transform.position);
            transform.position = newPosition;

        }
        
    }

}

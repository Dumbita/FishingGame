using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMovement : MonoBehaviour
{

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

    }
    private void Right()
    {

        fish.velocity = new Vector2(10, 0);

    }
    //chance of being trash of a fish
    private void EnemySpawning()
    {

        int chance = Random.Range(0, 100);

        if (chance > 40)
        {

            basic.color = Color.green;

            gameObject.tag = "FishGreen";

        }
        else if (chance < 60)
        {

            basic.color = Color.red;

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

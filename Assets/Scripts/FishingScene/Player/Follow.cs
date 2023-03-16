using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public static Vector2 mousePosition;
    Rigidbody2D rb;

    public bool restrictX = true;

    Camera mainCamera;

    public ScreenBounds screenBounds;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        mainCamera = FindObjectOfType<Camera>();
        
    }

    void Update()
    {
        //move in the y axis by following the cursor from main camera view
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //while blocking it from going outside screen
        if (screenBounds.AmIOutOfBounds(mousePosition) == false)
        {

            if (restrictX == true)
            {

                rb.MovePosition(new Vector2(rb.position.x, mousePosition.y));

            }

        }
    
    }

}

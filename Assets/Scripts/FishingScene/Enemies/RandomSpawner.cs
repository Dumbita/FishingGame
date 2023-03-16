using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    public GameObject enemy;

    private GameObject a;

    private GameObject b;

    private Vector2 screenBound;

    void Start()
    {

        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
    }

    private void LeftSpawner()
    {

        a = Instantiate(enemy) as GameObject;

        a.transform.position = new Vector2(-screenBound.x +2, Random.Range(-screenBound.y,screenBound.y));

        Destroy(a, 3f);

    }
    private void RightSpawner()
    {

        b = Instantiate(enemy) as GameObject;

        b.transform.position = new Vector2(screenBound.x -2, Random.Range(-screenBound.y, screenBound.y));

        Destroy(b, 3f);

    }

    void Update()
    {
        // spawining random enemies in random specific locations
        if (Input.GetMouseButtonDown(0))
        {

            LeftSpawner();
            RightSpawner();

        }
        
    }

}

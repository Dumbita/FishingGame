using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    Text name;

    void Start()
    {

        name = GetComponent<Text>();
        name.text = "Score " + Collision.count + " / 100";
        
    }

    void Update()
    {

        name.text = "Score " + Collision.count + " / 100";

    }

}

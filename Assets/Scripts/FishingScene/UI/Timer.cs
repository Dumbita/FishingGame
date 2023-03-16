using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timer;
    int count;

    public static float prof;

    public Text result;

    public GameObject[] testing;

    void Start()
    {

        count = 30;
        result.enabled = false;

        for (int i = 0; i < testing.Length; i++)
        {

            testing[i].active = true;

        }

        StartCoroutine(CountDown(1f));

    }

    IEnumerator CountDown(float f)
    {

        timer.text = count.ToString();

        yield return new WaitForSeconds(f);

        count--;

        if (count! > 0)
        {

            StartCoroutine(CountDown(f));

        }

    }

    void Update()
    {

        if (count == 0)
        {

            timer.text = count.ToString();

            for (int i = 0; i < testing.Length; i++)
            {

                testing[i].active = false;

            }

            float percentage = ( Collision.contaminated / Collision.count) * 100;

            result.enabled = true;

            float profit = (Collision.count - Collision.contaminated) * 30f;

            prof = profit;

            result.text = percentage + "% contaminated\n" + "profit " + profit;

            if (Input.GetMouseButtonDown(0))
            {

                SceneManager.LoadScene("StartScreen");

            }

        }

    }

}

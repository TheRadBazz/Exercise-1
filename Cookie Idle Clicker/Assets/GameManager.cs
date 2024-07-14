using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float cookieCount = 0f;
    public GameObject cookieText, cpsText;
    public float cps = 0f;
    public int cookieUpgrade = 0;
    /*private float timePassed = 0f; */
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
        UpdateCpsText();
    }

    // Update is called once per frame
    void Update()
    {

        if (cps > 0f)
        {
            cookieCount = cookieCount + (cps * Time.deltaTime);
            UpdateText();
        }
    }
    public void AddCookie()
    {
        cookieCount++;
        UpdateText();
        GameObject.Find("ClickButton").GetComponent<Animation>().Stop("CookieAnimation");
        GameObject.Find("ClickButton").GetComponent<Animation>().Play("CookieAnimation");

    }

    private void UpdateText()
    {
        cookieText.GetComponent<TMP_Text>().text = "Cookies " + cookieCount.ToString("F0");
    }
    private void UpdateCpsText()
    {
        if (cookieCount > 2000)
        {
            cookieUpgrade = 2000;
            cps = cps * 2;

        }


    }

    public void IncreaseCps()
    {
        if (cookieCount >= 10)
        {
            cookieCount = cookieCount - 10;
            cps++;
            UpdateText();
            cpsText.GetComponent<TMP_Text>().text = "Upgrade Clicks Per Second " + cookieUpgrade + "Cookies Required";
            Debug.Log("Our Clicks per second is now " + cps.ToString());
        }
    }
}

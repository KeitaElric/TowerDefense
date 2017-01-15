using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretBoxNotiMenu : MonoBehaviour {
    System.Random rnd = new System.Random();
    public Text resultText;
    public GameObject ui;
    public string menuToLoad = "MainMenu";
    private enum SECRETTYPE
    {
        LIVE,
        MONEY
    }
    private SECRETTYPE[] secrettypes = new[] { SECRETTYPE.LIVE, SECRETTYPE.MONEY };
	// Update is called once per frame
	void Update () {
        if (SecretBox.isShowNotiMenu && !ui.activeSelf)
        {
            Toggle();
            Destroy(SecretBox.currentBox);
            SecretBox.currentBox = null;
            object[] secret = (object[])GetRandom();
            SECRETTYPE type = (SECRETTYPE)secret[0];
            int number = (int)secret[1];
            switch (type)
            {
                case SECRETTYPE.LIVE:
                    {
                        if(number > 0)
                            resultText.text = string.Format("You Get {0} Live", Math.Abs(number));
                        else
                            resultText.text = string.Format("You Lose {0} Live", Math.Abs(number));
                        PlayerStats.Lives += number;
                    }
                    break;

                case SECRETTYPE.MONEY:
                    {
                        if (number > 0)
                            resultText.text = string.Format("You Get {0}$", Math.Abs(number));
                        else
                            resultText.text = string.Format("You Lose {0}$", Math.Abs(number));
                        PlayerStats.Money += number;
                    }
                    break;

                default:
                    break;
            }
        }
	}
    private object GetRandom()
    {
        var type = (SECRETTYPE)rnd.Next(0, secrettypes.Length);
        switch (type)
        {
            case SECRETTYPE.LIVE:
                {
                    return new object[]
                    {
                        SECRETTYPE.LIVE,
                        rnd.Next(-5, 5)
                    };
                }
                break;

            case SECRETTYPE.MONEY:
                {
                    return new object[]
                    {
                        SECRETTYPE.MONEY,
                        rnd.Next(-100, 101)
                    };
                }
                break;

            default:
                return null;
        }
        return new object[] { SECRETTYPE.LIVE, 1 };
    }
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            SecretBox.isShowNotiMenu = false;
        }
    }
}

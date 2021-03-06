﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    private Text ResultText;
    GameObject Resultdeliver;
    ResultDeliver Resultdeliverscript;

    GameObject Textdeliver;
    TextDeliver Textdeliverscript;
    // Start is called before the first frame update
    void Start()
    {
        Resultdeliver = GameObject.Find("ResultDeliver");
        Resultdeliverscript = Resultdeliver.GetComponent<ResultDeliver>();

        Textdeliver = GameObject.Find("DeliverText");
        Textdeliverscript = Textdeliver.GetComponent<TextDeliver>();

        ResultText = GetComponentInChildren<Text>();
        ResultText.text = "あなたの力で\n" + Resultdeliverscript.deliverString + "に\n届きました\n\nメッセージ内容\n" + Textdeliverscript.deliverText;
        Debug.Log(Textdeliverscript.deliverText);
    }

    // Update is called once per frame
    void Update()
    {
        if (TouchManager.Instance.m_TouchFlag)
        {
            MySceneManager.Instance.ChangeScene(MySceneManager.E_Scene.MAIN);
        }
    }
}

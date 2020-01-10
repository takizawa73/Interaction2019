using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    private Text ResultText;
    GameObject Resultdeliver;
    ResultDeliver Resultdeliverscript;
    // Start is called before the first frame update
    void Start()
    {
        Resultdeliver = GameObject.Find("ResultDeliver");
        Resultdeliverscript = Resultdeliver.GetComponent<ResultDeliver>();

        ResultText = GetComponentInChildren<Text>();
        ResultText.text = "あなたの力で\n" + Resultdeliverscript.deliverString + "に\n届きました";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

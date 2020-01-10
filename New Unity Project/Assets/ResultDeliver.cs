using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDeliver : MonoBehaviour
{
    public string deliverString;

    GameObject Sumaho;
    DecideSendCountry DecideSendscript;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        Sumaho = GameObject.Find("Sumaho");
        DecideSendscript = Sumaho.GetComponent<DecideSendCountry>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeliverStr()
    {
        deliverString = DecideSendscript.ResultCountry;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AccBarCtrl : MonoBehaviour
{
    Slider _slider;

    GameObject Sumaho;
    SumAcceleration SumAccscript;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        Sumaho = GameObject.Find("Sumaho");
        SumAccscript = Sumaho.GetComponent<SumAcceleration>();
    }

    // Update is called once per frame
    float acc = 0;
    void Update()
    {
        //Debug.Log("AccBarCtrl:" + SumAccscript.Distance);
        acc += (float)SumAccscript.Distance / 250000000;
        _slider.value = acc;
    }
}

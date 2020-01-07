using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendMessageRegisterer : MonoBehaviour
{
    public GameManager gm;
    public float distance=10.0f;
    public Text userName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Register(){
        gm.SendMesRegister(userName.text,distance);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SendMessageRegisterer : MonoBehaviour
{
    public GameManager gm;
    public float distance=10.0f;
    public Text message;
    public Text destination;

    public Text reciveMes;
    public Text fromplace;
    public Text username;
    public Text sendDate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Register(){
        //gm.SendMesRegister(userName.text,distance);
        gm.SaveSendMessage(message.text,destination.text);
    }

    public void RecieveMessageRegister(){
        gm.SaveRecieveMessage(reciveMes.text,fromplace.text,username.text,sendDate.text);
        //Debug.Log("completed!"+reciveMes.text);
    }
    public void GoConfigScene(){
        SceneManager.LoadScene("Config");
    }
}

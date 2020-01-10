using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ConfigUIManager : MonoBehaviour
{
    public GameManager gm;
    public Text sendMessages;
    public Text recieveMessages;
    public Canvas sendShowCan;
    public Canvas recieveShowCan;

    public Canvas userChangeCan;
    public Text nameText;
    public Text placeText;
    public Text originName;
    public Text originPlace;
    

    // Start is called before the first frame update
    void Start()
    {
        sendShowCan.enabled=false;
        userChangeCan.enabled=false;
        recieveShowCan.enabled=false;
        
    }

    // Update is called once per frame
    void Update()
    {
        nameText.text=gm.user.nickname;
        placeText.text=gm.user.comeplace;
        originName.text=gm.user.nickname;
        originPlace.text=gm.user.comeplace;
        /*
        if(Input.GetKeyDown(KeyCode.Space)){
            gm.MessageAllDelete();
        }
        */
    }

    public void GetSentMes(){
        sendShowCan.enabled=true;
        sendMessages.text="";
        for(int i=0;i<gm.user.sentMessages.Count;i++){
            sendMessages.text+="送信日：\n"+gm.user.sentMessages[i].dateTime+"\n";
            //Debug.Log(gm.user.sentMessages[i].dateTime);
            sendMessages.text+="宛先："+gm.user.sentMessages[i].destination+"\n";
            sendMessages.text+="発信元："+gm.user.sentMessages[i].sendPlace+"\n";
            //sendMessages.text+="発信元："+gm.user.sentMessages[i].distance.ToString()+"\n";
            sendMessages.text+="メッセージ：\n"+gm.user.sentMessages[i].sendMessage+"\n"+"\n"+"\n";
        }
    }

    public void CloseSentMes(){
        sendShowCan.enabled=false;
        sendMessages.text="";
    }

    public void GetRecieveMes(){
        recieveShowCan.enabled=true;
        recieveMessages.text="";
        Debug.Log(gm.user.recieveMessages.Count);
        for(int i=0;i<gm.user.recieveMessages.Count;i++){
            recieveMessages.text+="送信日：\n"+gm.user.recieveMessages[i].sendDateTime+"\n";
            //Debug.Log(gm.user.sentMessages[i].dateTime);
            recieveMessages.text+="受信日：\n"+gm.user.recieveMessages[i].recieveDateTime+"\n";
            recieveMessages.text+="発信元："+gm.user.recieveMessages[i].fromPlace+"\n";
            //sendMessages.text+="発信元："+gm.user.sentMessages[i].distance.ToString()+"\n";
            recieveMessages.text+="メッセージ：\n"+gm.user.recieveMessages[i].recieveMessage+"\n"+"\n"+"\n";
            //Debug.Log(gm.user.recieveMessages[i].recieveMessage);
        }
    }

    public void CloseRecieveMes(){
        recieveShowCan.enabled=false;
        recieveMessages.text="";
    }
    public void OpenUserChan(){
        
        userChangeCan.enabled=true;
        
    }
    public void CloseUserChan(){
        userChangeCan.enabled=false;
    }

    public void GoMessageRegisterScene(){
        SceneManager.LoadScene("MesRegister");
    }
}

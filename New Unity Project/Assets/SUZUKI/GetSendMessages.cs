using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSendMessages : MonoBehaviour
{
    public GameManager gm;
    public Text sendMessages;
    public Canvas sendShowCan;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        nameText.text=gm.user.nickname;
        placeText.text=gm.user.comeplace;
        originName.text=gm.user.nickname;
        originPlace.text=gm.user.comeplace;
    }

    public void GetSentMes(){
        sendShowCan.enabled=true;
        sendMessages.text="";
        for(int i=0;i<gm.user.sentMessages.Count;i++){
            sendMessages.text+=gm.user.sentMessages[i].dateTime.ToString()+"\n";
            sendMessages.text+=gm.user.sentMessages[i].sendPlace+"\n";
            sendMessages.text+=gm.user.sentMessages[i].distance.ToString()+"\n";
            sendMessages.text+=gm.user.sentMessages[i].sendMessage+"\n"+"\n"+"\n";
        }
    }
    public void CloseSentMes(){
        sendShowCan.enabled=false;
        sendMessages.text="";
    }
    public void OpenUserChan(){
        
        userChangeCan.enabled=true;
        
    }
    public void CloseUserChan(){
        userChangeCan.enabled=false;
    }
}

using System;
[System.Serializable]

//受信メッセージ記録クラス
public class RecieveMessage {
    public string recieveMessage;       //受信メッセージ内容
    public string fromPlace;         //送信場所
    //public float distance;            //距離
    public string username;             //送信ユーザー
    public string sendDateTime;           //送信日
    public string recieveDateTime;           //送信日
    
}

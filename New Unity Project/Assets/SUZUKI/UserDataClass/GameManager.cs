using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//セーブデータの管理をするクラス
//それぞれのシーンに配置して使ってください（セーブデータはシーン遷移の都度読み込まれます）
public class GameManager : Singleton<GameManager> {

    const string _SaveKey = "UserData";
    public User user;

    void Start () {
        //読込
        string json = PlayerPrefs.GetString(_SaveKey);
        user = JsonUtility.FromJson<User>(json);
    }

    void Update () {

    }

    //データ保存（変数userの情報がjsonで記録される）
    void Save () {
        string json = JsonUtility.ToJson( user );
        PlayerPrefs.SetString(_SaveKey, json);
    }

    //ユーザー登録
    public void UserRegister(string name,string place){
        if (user == null)
        {
            user = new User();
        }
        user.nickname=name;
        user.comeplace=place;
        Save();
        MySceneManager.Instance.ChangeScene(MySceneManager.E_Scene.MAIN);
    }

    //送信メッセージを保存　メッセージ内容と目的地
    public void SaveSendMessage(string message,string dest){
        SentMessage st=new SentMessage();
        st.sendMessage=message;
        st.sendPlace=user.comeplace;
        st.dateTime=DateTime.Now.ToString();
        //Debug.Log(DateTime.Now);
        //st.distance=distance;
        st.destination=dest;
        user.sentMessages.Add(st);
        Save();
    }

    //受信メッセージを保存　メッセージ内容と発信元、発信ユーザー名
    public void SaveRecieveMessage(string message,string place,string name,string sendDate){
        RecieveMessage rm=new RecieveMessage();
        rm.recieveMessage=message;
        rm.recieveDateTime=DateTime.Now.ToString();
        rm.fromPlace=place;
        rm.username=name;
        rm.sendDateTime=sendDate;
        //st.distance=distance;
        user.recieveMessages.Add(rm);
        Save();
    }

    //送信メッセージの履歴　全消去
    public void MessageAllDelete(){
        user.sentMessages.RemoveRange(0,user.sentMessages.Count);
        Save();
    }

    //受信メッセージの履歴　全消去
    public void recieveMessageAllDelete(){
        user.recieveMessages.RemoveRange(0,user.recieveMessages.Count);
        Save();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager> {

    const string _SaveKey = "UserData";
    public User user;

    void Start () {
        //読込
        string json = PlayerPrefs.GetString(_SaveKey);
        user = JsonUtility.FromJson<User>(json);
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            LevelUp();
        }
    }

    void LevelUp () {
        user.level += 1;
        Save();
    }

    //保存
    void Save () {
        string json = JsonUtility.ToJson( user );
        PlayerPrefs.SetString(_SaveKey, json);
    }

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
    public void SendMesRegister(string message,float distance){
        SentMessage st=new SentMessage();
        st.sendMessage=message;
        st.sendPlace=user.comeplace;
        st.dateTime=DateTime.Now;
        st.distance=distance;
        user.sentMessages.Add(st);
        Save();
    }
}

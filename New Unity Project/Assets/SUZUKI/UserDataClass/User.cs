using System.Collections.Generic;

//ユーザー情報記録クラス
[System.Serializable]
public class User {
    public string nickname;                     //ユーザー名
    public string comeplace;                    //ユーザー住所             
    public List<SentMessage> sentMessages;      //送信メッセージ履歴
    public List<RecieveMessage> recieveMessages;      //送信メッセージ履歴
}


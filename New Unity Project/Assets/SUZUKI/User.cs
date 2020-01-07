using System.Collections.Generic;

[System.Serializable]
public class User {
    public string nickname;
    public string comeplace;
    public int level, exp;
    public List<SentMessage> sentMessages;
}

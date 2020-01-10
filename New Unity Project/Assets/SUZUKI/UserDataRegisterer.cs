using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserDataRegisterer : MonoBehaviour
{
    public GameManager gm;
    public Text userName;
    public Text userPlace;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Register(){
        gm.UserRegister(userName.text, userPlace.text);
    }
}

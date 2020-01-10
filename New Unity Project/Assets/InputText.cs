using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputText : MonoBehaviour
{
    public InputField GetInput;
    public string text;

    GameObject Delivertext;
    TextDeliver Delivertextscript;

    public void InputT()
    {
        text = GetInput.text;
        Debug.Log(text);
        //GetInput.text = null;
        Delivertextscript.deliverText = text;
        SceneManager.LoadScene("ShakeScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        Delivertext = GameObject.Find("DeliverText");
        Delivertextscript = Delivertext.GetComponent<TextDeliver>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

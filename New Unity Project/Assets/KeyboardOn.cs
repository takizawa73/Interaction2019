using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardOn : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;
    string inputtedtext;
    
    // Start is called before the first frame update
    void Start()
    {
        this.keyboard = TouchScreenKeyboard.Open("shokiti", TouchScreenKeyboardType.Default);
    }

    // Update is called once per frame
    void Update()
    {
        inputtedtext = keyboard.text;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

    private InputField input;
    private LexicalAnalyzer scanner;

    private bool pcExists = true;

    void Start()
    {
        input = transform.GetComponent<InputField>();
        scanner = FindObjectOfType<LexicalAnalyzer>();
    }

    void Update()
    {
        if (!input.text.Equals("") && pcExists)
        {
            if (input.transform.GetChild(0).name == "pc")
                input.transform.GetChild(0).GetComponent<Text>().text = "";
            else
                input.transform.GetChild(1).GetComponent<Text>().text = "";

            pcExists = false;
        }
        if (Input.GetKeyDown(KeyCode.Semicolon) && (!input.text.Equals("") && !input.text.StartsWith(";")))
        {
            scanner.setInput(input.text.ToString());
            scanner.StartScan();
            input.text = "";
        }
    }

    public string getInput()
    {
        return input.ToString();
    }

    public void SetInput(string s)
    {
        input.text = s;
    }
}

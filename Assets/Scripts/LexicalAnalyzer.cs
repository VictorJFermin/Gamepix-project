using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Lexycal Analyzer is a Scanner that simply turns an input String (say a file) into a list of tokens. 
/// These tokens represent things like identifiers, parentheses, operators etc.
/// </summary>
public class LexicalAnalyzer : MonoBehaviour {

    private SyntaxAnalyzer parser;

    private string input;
    private string[] splitText;
    private Dictionary<int, string> dictionary;

    //REGEX; @"^(\'|\~)([a-zA-Z]+) ([a-zA-Z]+) (\d+)$"

    void Start()
    {
        parser = FindObjectOfType<SyntaxAnalyzer>();

        input = "";
        dictionary = new Dictionary<int, string>();
    }

    private void Scanner()
    {

        splitText = input.Split(new char[] { ' ', '\t', ';' });
        
        for (int i = 0; i < splitText.Length-1; i++)
        {
            Debug.Log(splitText[i]);
            dictionary.Add(i, splitText[i]);
        }
        parser.ClearVariables();
        parser.ParseTokens(dictionary);
        CleanDictionary();
    }

    public void StartScan()
    {
        Scanner();
    }

    public void setInput(string s)
    {
        input = s;
    }

    public string getInput()
    {
        return input;
    }
    
    public Dictionary<int, string> getDictionary()
    {
        return dictionary;
    }

    public void SetDictionary(Dictionary<int, string> d)
    {
        dictionary = d;
    }

    public void CleanDictionary()
    {
        dictionary.Clear();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeManager : MonoBehaviour
{
    private WindowController window;

    public GameObject codeText;
    public Scrollbar scrollbar;
    private int count = 0;

    private GameObject[] codesArray;
    private GameObject codesParent;

    void Awake()
    {
        window = FindObjectOfType<WindowController>();
        codesArray = new GameObject[800];
        codesParent = transform.GetChild(0).GetChild(0).gameObject;
    }

    public void CodeSentence(string sentence)
    {
        codesArray[count] = Instantiate(codeText) as GameObject;
        codesArray[count].transform.SetParent(codesParent.transform);
        codesArray[count].transform.localScale = Vector3.one;
        codesArray[count].GetComponent<Text>().text = "" + (1 + count) + ".\t" + sentence;
        count++;

        window.Themes(WindowController.GetLastTheme());
        StartCoroutine(SecToWait(0.2f));
    }

    IEnumerator SecToWait(float wait)
    {
        yield return new WaitForSeconds(wait);
        scrollbar.value = 0;
    }

    public void UpdateCode(string linenumber, string parenthesis, string functionName, string normalText)
    {
        Color ln;
        Color pa;
        Color fn;
        Color nt;
        ColorUtility.TryParseHtmlString(linenumber, out ln);
        ColorUtility.TryParseHtmlString(parenthesis, out pa);
        ColorUtility.TryParseHtmlString(functionName, out fn);
        ColorUtility.TryParseHtmlString(normalText, out nt);
        
        for (int i = 0; i < count; i++)
        {
            /* string[] splitText = codesArray[i].GetComponent<Text>().text.Split(new char[] { ' ', '\t', ';' , '(', ')'});
             string number = "<color=" + linenumber + ">" + splitText[0] + "</color>     ";
             string fName = "<color=" + functionName + ">" + splitText[1] + "</color> ";
             string nText = "";
             string restText = "";
             if (splitText.Length > 2)
                 nText = "<color=" + normalText + ">" + splitText[2] + "</color><color=" + parenthesis + ">(</color>";
             if(splitText.Length > 3)
                 for(int j = 3; j < splitText.Length; j++)
                 {
                     restText += "<color=" + normalText + ">" + splitText[j] + "</color>";
                 }

             restText += "<color=" + parenthesis + ">)</color>";
             string AddAll = number + fName + nText + restText;
             codesArray[i].GetComponent<Text>().text = AddAll;*/
            codesArray[i].GetComponent<Text>().color = ln;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Syntax Analyzer is a A parser converts this list of tokens into a Tree-like object to represent how the tokens 
/// fit together to form a cohesive whole (sometimes referred to as a sentence). For this project we will have tokens for:
/// createFunction, function, identifier and integers.
/// </summary>
public class SyntaxAnalyzer : MonoBehaviour
{
    private GameFunctions gameFunction;
    private DialogManager dialogManager;

    private Dictionary<int, string> dictionary;
    private string createFunctionName = "";
    private string normalFunctionName = "";
    private string objectName = "";

    // PARAMETER TYPES AND VARIABLES;
    private int _1parami = 0;
    private float _1paramf = 0f;
    private Color _1paramc = Color.white;
    private bool _1paramb = false;
    private float _2paramf = 0f;
    private Color _2paramc = Color.white;
    private KeyCode _2paramk = KeyCode.Return;
    private float _3paramf = 0f;
    private KeyCode _3paramk = KeyCode.Return;


    void Awake()
    {
        gameFunction = FindObjectOfType<GameFunctions>();
        dialogManager = FindObjectOfType<DialogManager>();
    }
    void Start()
    {
        dictionary = new Dictionary<int, string>();
    }

    public void ParseTokens(Dictionary<int, string> dic)
    {
        dictionary = dic;
    
        // FIRST ELEMENT IN THE STRING MUST BE A FUNCTION.
        if (!isValidFunction(dictionary[0]))
            return;
        if (dictionary[0] == "~Helpcfn" || dictionary[0] == "~Helpnfn")
        {
            CallGameFunctions();
            return;
        }
        Debug.Log("Should continue");

        // SECOND ELEMENT IN THE STRING MUST BE AN IDENTIFIER.
        if (!isValidIdentifier(dictionary[1]))
            return;
        Debug.Log("Should Continue2");

        // ALL STATEMENTS HAS UP TO 4 PARAMETERS
        int parameters = dictionary.Count - 2;
        if (parameters > 3 || parameters < 0)
        {
            Debug.Log("Error: ALL STATEMENTS HAVE UP TO 3 PARAMETERS THIS ONE HAS: " + parameters.ToString());
            dialogManager.DialogSentence("All statements have up to 3 parameters, this one has: " + parameters.ToString(), "<color=red>Error: </color>", 2);
            return;
        }
        Debug.Log("should continue3");

        if (!isValidParameters(parameters))
            return;

        Debug.Log("Should continue4");

        // LETS CALL THE GAME FUNCTION NOW
        CallGameFunctions();

    }

    private bool isValidFunction(string s)
    {
        if (s[0] == '\'')
        {
            Debug.Log("aposterphe");
            return CheckCreateFunctionSyntax(s);
        }
        else if (s[0] == '~')
        {
            Debug.Log("tilde");
            return CheckNormalFunctionSyntax(s);
        }
        // SYNTAX ERROR SINCE FIRST ELEMENT IN STRING IS NOT A FUNCTION.
        dialogManager.DialogSentence("The first element you type in the string is not a function. To start a create function use" +
            "('), to start a normal function use (~).", "<color=red>Syntax Error:   </color>", 3);

        return false;
    }

    private bool isValidIdentifier(string s)
    {
        if (s[0] == '\'' || s[0] == '~')
        {
            // SYNTAX ERROR SINCE SECOND ELEMENT CANNOT BE A TYPE FUNCTION.
            Debug.Log("The second element must not be a type Function: " + s);
            dialogManager.DialogSentence("The second element in the sentence must not be a function, therefore you can't start with (') or (~)", "<color=red>Syntax Error:   </color>", 4);
            return false;
        }
        return CheckValidIdentifier(s);

    }

    private bool isValidParameters(int parameters)
    {
        string cfn = createFunctionName;
        string nfn = normalFunctionName;

        if ((nfn == "Destroy" || nfn == "Helpcfn" || nfn == "Helpnfn") && parameters != 0)
        {
            // PARAMETER EXCEPTION ERROR, NOT THE CORRECT QUANTITY OF PARAMETERS FOR THE GIVEN FUNCTION
            Debug.Log("The function named: " + cfn + nfn + " should have 0 parameter and not: " + parameters.ToString());
            dialogManager.DialogSentence("The function named " + cfn + nfn + " should have 0 parameter and not: " + parameters.ToString(), "<color=red>Syntax Error:   </color>", 5);
            return false;
        }
        else if ((cfn == "Body" || cfn == "PlaneX" || cfn == "PlaneY" || cfn == "Square" || cfn == "Circle" || cfn == "CircleFill" ||
            nfn == "ColorAll" || nfn == "Gravity" || nfn == "BoxCollider" || nfn == "CircleCollider" || nfn == "SpeedXLoop" ||
            nfn == "SpeedYLoop" || nfn == "MakeInvisible") && parameters != 1)
        {
            // PARAMETER EXCEPTION ERROR, NOT THE CORRECT QUANTITY OF PARAMETERS FOR GIVEN FUNCTION
            Debug.Log("The function named: " + cfn + nfn + " should have only 1 parameter and not: " + parameters.ToString());
            dialogManager.DialogSentence("The function named " + cfn + nfn + " should have only 1 parameter and not: " + parameters.ToString(), "<color=red>Syntax Error:   </color>", 2);
            return false;
        }
        else if ((nfn == "SetPosition" || nfn == "ColorChild" || nfn == "Jumpforce") && parameters != 2)
        {
            // PARAMETER EXCEPTION ERROR, NOT THE CORRECT QUANTITY OF PARAMETERS FOR THE GIVEN FUNCTION.
            Debug.Log("The function named: " + cfn + nfn + " should have 2 parameters and not: " + parameters.ToString());
            dialogManager.DialogSentence("The function named " + cfn + nfn + " should have 2 parameters and not: " + parameters.ToString(), "<color=red>Syntax Error:   </color>", 3);
            return false;
        }
        else if ((nfn == "SetLocalPosition" || nfn == "SpeedX" || nfn == "SpeedY" || cfn == "RainInstantiate") && parameters != 3)
        {
            // PARAMETER EXCEPTION ERROR, NOT THE CORRECT QUANTITY OF PARAMETERS FOR THE GIVEN FUNCTION.
            Debug.Log("The function named: " + cfn + nfn + " should have only 3 parameters and not: " + parameters.ToString());
            dialogManager.DialogSentence("The function named " + cfn + nfn + " should have 3 parameters and not: " + parameters.ToString(), "<color=red>Syntax Error:   </color>", 4);
            return false;
        }

        Debug.Log("Perfect! The function name: " + nfn + cfn + " has " + parameters.ToString() + " parameters");

        bool syntax;
        if (cfn == "")
            syntax = CheckParametersSyntax(nfn);
        else
            syntax = CheckParametersSyntax(cfn);

        return syntax;
    }

    private bool CheckCreateFunctionSyntax(string s)
    {
        string cfn = s.Substring(1);
        bool correctSyntax;

        if (cfn == "Body" || cfn == "PlaneX" || cfn == "PlaneY" || cfn == "Square" || cfn == "Circle" || cfn == "CircleFill" || cfn == "RainInstantiate")
        {
            correctSyntax = true;
            createFunctionName = cfn;
            Debug.Log("The Create FunctionName is: " + createFunctionName);
        }
        else
        {
            correctSyntax = false;
            createFunctionName = "";
            Debug.Log("The Create FunctionName is Wrong Typed: " + cfn);
            dialogManager.DialogSentence("The Create function name you typed: " + cfn + " does not exist. If you need me to remember you the "+
                "create function names type: ~Helpcfn", "<color=red>Syntax Error:   </color>", 5);
        }


        return correctSyntax;
    }

    private bool CheckNormalFunctionSyntax(string s)
    {
        string nfn = s.Substring(1);
        bool correctSyntax = true;

        if (nfn == "SetPosition" || nfn == "SetLocalPosition" || nfn == "ColorAll" || nfn == "ColorChild" || nfn == "Gravity" ||
            nfn == "BoxCollider" || nfn == "CircleCollider" || nfn == "SpeedX" || nfn == "SpeedY" || nfn == "SpeedXLoop" ||
            nfn == "SpeedYLoop" || nfn == "Jumpforce" || nfn == "Destroy" || nfn == "MakeInvisible" || nfn == "Helpcfn" ||
            nfn == "Helpnfn" || nfn == "DestroyInCollision") 
        {
            correctSyntax = true;
            normalFunctionName = nfn;
            Debug.Log("The Normal FuncionName is: " + normalFunctionName);
        }
        else
        {
            correctSyntax = false;
            normalFunctionName = "";
            Debug.Log("The Normal FuncionName is wrong Typed: " + nfn);
            dialogManager.DialogSentence("The Normal function name you typed: " + nfn + " does not exist. If you need me to remember you the " +
                "normal function names type: ~Helpnfn", "<color=red>Syntax Error:   </color>", 2);
        }

        return correctSyntax;
    }

    private bool CheckValidIdentifier(string s)
    {
        bool variableExists = (GameObject.Find(s) == null) ? false : true;

        if (createFunctionName != "" && variableExists)
        {
            // CAN'T CREATE THE NEW OBJECT BECAUSE THE VARIABLE ALREADY EXITS.
            Debug.Log("Couldnt create Object because the variable: " + s + " already exists in the game");
            dialogManager.DialogSentence("Couldn't create the object, because the variable: " + s + " already exists in the game.", "<color=red>Error:   </color>", 3);
            return false;
        }
        else if (normalFunctionName != "" && !variableExists)
        {
            // VARIABLE DOESN'T EXISTS
            Debug.Log("Cant work with the normal function since there is no: " + s + " variable in the game");
            dialogManager.DialogSentence("Couldn't execute function because the variable: " + s + " doesn't exist in the game.", "<color=red>Error:   </color>", 4);
            return false;
        }

        objectName = s;
        return true;
    }



    private bool CheckParametersSyntax(string s)
    {
        bool syntax = true;
        bool isInteger;
        bool isFloat;
        bool isFloat2;
        bool isColor;
        bool isBool;
        bool isKey;
        bool isKey2;
        int childs;

        switch (s)
        {
            case "Body":
                isInteger = int.TryParse(dictionary[2], out _1parami);
                if (isInteger && _1parami > 0)
                {
                    Debug.Log("Valid parameters!");

                }
                else
                {
                    if (!isInteger)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[2] + " is no integer");
                        dialogManager.DialogSentence("Parameter " + dictionary[2] + " is not type integer.", "<color=red>Syntax Error:   </color>", 5);
                    }
                    else
                    {
                        Debug.Log("Childs can not be less than 0.. you typed: " + _1parami.ToString());
                        dialogManager.DialogSentence("Childs in the creative function must be greater than 0, you typed: " + _1parami.ToString(), "<color=red>Syntax Error:   </color>",2);
                    }

                    syntax = false;
                }
                break;
            case "PlaneX":
            case "PlaneY":
            case "Gravity":
            case "SpeedXLoop":
            case "SpeedYLoop":
                isFloat = float.TryParse(dictionary[2], out _1paramf);
                if (isFloat)
                {
                    Debug.Log("Valid parameters!");
                }
                else
                {
                    Debug.Log("Sorry, parameter: " + dictionary[2] + " is no float");
                    dialogManager.DialogSentence("Parameter " + dictionary[2] + " is not type float", "<color=red>Syntax Error:   </color>", 3);
                    syntax = false;
                }
                break;
            case "Square":
            case "Circle":
            case "CircleFill":
                isFloat = float.TryParse(dictionary[2], out _1paramf);
                if (isFloat && _1paramf >= 0)
                {
                    Debug.Log("Valid parameter!");
                }
                else
                {
                    if (!isFloat)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[2] + " is no float");
                        dialogManager.DialogSentence("Parameter " + dictionary[2] + " is not type float", "<color=red>Syntax Error:   </color>", 4);
                    }
                    else
                    { 
                        Debug.Log("Parameter must be greater than 0, you typed: " + _1paramf.ToString());
                        dialogManager.DialogSentence("The width/radious must be greater than 0, you typed: " + _1paramf.ToString(), "<color=red>Syntax Error:   </color>", 5);
                    }
                    syntax = false;
                }
                break;
            case "SetPosition":
                isFloat = float.TryParse(dictionary[2], out _1paramf);
                isFloat2 = float.TryParse(dictionary[3], out _2paramf);
                if (isFloat && isFloat2)
                {
                    Debug.Log("Valid parameters!!");
                }
                else
                {
                    if (!isFloat)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[2] + " is no float");
                        dialogManager.DialogSentence("Parameter " + dictionary[2] + " is not type float", "<color=red>Syntax Error:   </color>", 2);

                    }
                    if (!isFloat2)
                    { 
                        Debug.Log("Sorry, parameter: " + dictionary[3] + " is no float");
                        dialogManager.DialogSentence("Parameter " + dictionary[3] + " is not type float", "<color=red>Syntax Error:   </color>", 3);
                    }

                    syntax = false;
                }
                break;
            case "SetLocalPosition":
                isInteger = int.TryParse(dictionary[2], out _1parami);
                isFloat = float.TryParse(dictionary[3], out _2paramf);
                isFloat2 = float.TryParse(dictionary[4], out _3paramf);

                childs = GameObject.Find(objectName).transform.childCount;

                if (isInteger && isFloat && isFloat2 && _1parami >= 0 && _1parami < childs)
                {
                    Debug.Log("Valid parameters!!!");
                }
                else
                {
                    if (!isInteger)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[2] + " is no integer");
                        dialogManager.DialogSentence("Parameter " + dictionary[2] + " is not type integer", "<color=red>Syntax Error:   </color>", 4);
                    }
                    if (!isFloat)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[3] + " is no float");
                        dialogManager.DialogSentence("Parameter " + dictionary[3] + " is not type float", "<color=red>Syntax Error:   </color>", 5);
                    }
                    if (!isFloat2)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[4] + " is no float");
                        dialogManager.DialogSentence("Parameter " + dictionary[4] + " is not type float", "<color=red>Syntax Error:   </color>", 2);
                    }
                    if (!(_1parami >= 0 && _1parami < childs))
                    {
                        Debug.Log("The child: " + dictionary[2] + " doesnt exists.");
                        dialogManager.DialogSentence("The child " + dictionary[2] + " doesn't exist.", "<color=red>Syntax Error:   </color>", 3);
                    }
                    syntax = false;
                }
                break;
            case "ColorAll":
                isColor = CheckValidColorName(dictionary[2], out _1paramc);
                if (isColor)
                {
                    Debug.Log("Valid parameters!!! and color = " + _1paramc.ToString());
                }
                else
                {
                    Debug.Log("Sorry, parameter: " + dictionary[2] + " is no color");
                    dialogManager.DialogSentence("Parameter " + dictionary[2] + " is not type color", "<color=red>Syntax Error:   </color>", 4);
                    syntax = false;
                }
                break;
            case "ColorChild":
                isInteger = int.TryParse(dictionary[2], out _1parami);
                isColor = CheckValidColorName(dictionary[3], out _2paramc);

                childs = GameObject.Find(objectName).transform.childCount;

                if (isInteger && isColor && _1parami >= 0 && _1parami < childs)
                {
                    Debug.Log("Valid Parameters!! Color = " + _2paramc.ToString() + " and child number: " + _1parami.ToString());
                }
                else
                {
                    if (!isInteger)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[2] + " is no integer");
                        dialogManager.DialogSentence("Parameter " + dictionary[2] + " is not type integer.", "<color=red>Syntax Error:   </color>", 5);
                    }
                    if (!isColor)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[3] + " is no color");
                        dialogManager.DialogSentence("Parameter " + dictionary[3] + " is not type float", "<color=red>Syntax Error:   </color>", 2);
                    }
                    if (!(_1parami >= 0 && _1parami < childs))
                    {
                        Debug.Log("The child: " + dictionary[2] + " doesnt exists.");
                        dialogManager.DialogSentence("The child " + dictionary[2] + " doesn't exist.", "<color=red>Syntax Error:   </color>",3);
                    }

                    syntax = false;
                }
                break;
            case "BoxCollider":
            case "CircleCollider":
            case "MakeInvisible":
                isBool = bool.TryParse(dictionary[2], out _1paramb);
                if (isBool)
                {
                    Debug.Log("Valid parameters!!! and boolean = " + _1paramb.ToString());
                }
                else
                {
                    Debug.Log("Sorry, parameter: " + dictionary[2] + " is no boolean");
                    dialogManager.DialogSentence("Parameter " + dictionary[2] + " is not type boolean", "<color=red>Syntax Error:   </color>", 4);
                    syntax = false;
                }
                break;
            case "SpeedX":
            case "SpeedY":
                isFloat = float.TryParse(dictionary[2], out _1paramf);
                isKey = CheckValidKeyCode(dictionary[3], out _2paramk);
                isKey2 = CheckValidKeyCode(dictionary[4], out _3paramk);

                if (isFloat && isKey && isKey2)
                {
                    Debug.Log("Valid parameters! keys are: " + _2paramk.ToString() + " - " + _3paramk.ToString());
                }
                else
                {
                    if (!isFloat)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[2] + " is no float");
                        dialogManager.DialogSentence("Parameter " + dictionary[2] + " is not type float", "<color=red>Syntax Error:   </color>", 5);
                    }
                    if (!isKey)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[3] + " is no valid Key");
                        dialogManager.DialogSentence("Parameter " + dictionary[3] + " is not a valid key", "<color=red>Syntax Error:   </color>", 2);
                    }
                    if (!isKey2)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[4] + " is no valid key");
                        dialogManager.DialogSentence("Parameter " + dictionary[4] + " is not a valid key", "<color=red>Syntax Error:   </color>", 3);
                    }

                    syntax = false;
                }
                break;
            case "Jumpforce":
                isFloat = float.TryParse(dictionary[2], out _1paramf);
                isKey = CheckValidKeyCode(dictionary[3], out _2paramk);

                if (isFloat && isKey)
                {
                    Debug.Log("Valid parameters! key is: " + _2paramk.ToString());
                }
                else
                {
                    if (!isFloat)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[2] + " is no float");
                        dialogManager.DialogSentence("Parameter " + dictionary[2] + " is not type float", "<color=red>Syntax Error:   </color>", 4);
                    }
                    if (!isKey)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[3] + " is no valid Key");
                        dialogManager.DialogSentence("Parameter " + dictionary[3] + " is not a valid key.", "<color=red>Syntax Error:   </color>", 5);
                    }

                    syntax = false;
                }
                break;
            case "RainInstantiate":
                isInteger = int.TryParse(dictionary[2], out _1parami);
                isFloat = float.TryParse(dictionary[3], out _2paramf);
                isFloat2 = float.TryParse(dictionary[4], out _3paramf);

                if (isInteger && isFloat && isFloat2)
                {
                    Debug.Log("Valid parameters!!!");
                }
                else
                {
                    if (!isInteger)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[2] + " is no integer");
                        dialogManager.DialogSentence("Parameter " + dictionary[2] + " is not type integer", "<color=red>Syntax Error:   </color>", 4);
                    }
                    if (!isFloat)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[3] + " is no float");
                        dialogManager.DialogSentence("Parameter " + dictionary[3] + " is not type float", "<color=red>Syntax Error:   </color>", 5);
                    }
                    if (!isFloat2)
                    {
                        Debug.Log("Sorry, parameter: " + dictionary[4] + " is no float");
                        dialogManager.DialogSentence("Parameter " + dictionary[4] + " is not type float", "<color=red>Syntax Error:   </color>", 2);
                    }
                    syntax = false;
                }
                break;
        }

        return syntax;
    }

    public void ClearVariables()
    {
        createFunctionName = "";
        normalFunctionName = "";
        objectName = "";
        _1parami = 0;
        _1paramf = 0f;
        _1paramc = Color.white;
        _1paramb = false;
        _2paramf = 0f;
        _2paramc = Color.white;
        _2paramk = KeyCode.Return;
        _3paramf = 0f;
        _3paramk = KeyCode.Return;
}

    private bool CheckValidColorName(string cName, out Color c)
    {
        bool etr = true;
        c = Color.white;

        switch (cName)
        {
            case "black":
            case "BLACK":
            case "Black":
                c = Color.black;
                break;
            case "blue":
            case "BLUE":
            case "Blue":
                c = Color.blue;
                break;
            case "cyan":
            case "CYAN":
            case "Cyan":
                c = Color.cyan;
                break;
            case "gray":
            case "GRAY":
            case "Gray":
                c = Color.gray;
                break;
            case "green":
            case "GREEN":
            case "Green":
                c = Color.green;
                break;
            case "grey":
            case "GREY":
            case "Grey":
                c = Color.grey;
                break;
            case "magenta":
            case "MAGENTA":
            case "Magenta":
                c = Color.magenta;
                break;
            case "red":
            case "RED":
            case "Red":
                c = Color.red;
                break;
            case "white":
            case "WHITE":
            case "White":
                c = Color.white;
                break;
            case "yellow":
            case "YELLOW":
            case "Yellow":
                c = Color.yellow;
                break;
            default:
                etr = false;
                break;
        }

        return etr;
    }

    private bool CheckValidKeyCode(string key, out KeyCode kCode)
    {
        bool etr = true;
        kCode = KeyCode.Return;

        switch (key)
        {
            case "q":
            case "Q":
                kCode = KeyCode.Q;
                break;
            case "w":
            case "W":
                kCode = KeyCode.W;
                break;
            case "e":
            case "E":
                kCode = KeyCode.Q;
                break;
            case "r":
            case "R":
                kCode = KeyCode.R;
                break;
            case "t":
            case "T":
                kCode = KeyCode.T;
                break;
            case "y":
            case "Y":
                kCode = KeyCode.Y;
                break;
            case "u":
            case "U":
                kCode = KeyCode.U;
                break;
            case "i":
            case "I":
                kCode = KeyCode.I;
                break;
            case "o":
            case "O":
                kCode = KeyCode.O;
                break;
            case "p":
            case "P":
                kCode = KeyCode.P;
                break;
            case "a":
            case "A":
                kCode = KeyCode.A;
                break;
            case "s":
            case "S":
                kCode = KeyCode.S;
                break;
            case "d":
            case "D":
                kCode = KeyCode.D;
                break;
            case "f":
            case "F":
                kCode = KeyCode.F;
                break;
            case "g":
            case "G":
                kCode = KeyCode.G;
                break;
            case "h":
            case "H":
                kCode = KeyCode.H;
                break;
            case "j":
            case "J":
                kCode = KeyCode.J;
                break;
            case "k":
            case "K":
                kCode = KeyCode.K;
                break;
            case "l":
            case "L":
                kCode = KeyCode.L;
                break;
            case "z":
            case "Z":
                kCode = KeyCode.Z;
                break;
            case "x":
            case "X":
                kCode = KeyCode.X;
                break;
            case "c":
            case "C":
                kCode = KeyCode.C;
                break;
            case "v":
            case "V":
                kCode = KeyCode.V;
                break;
            case "b":
            case "B":
                kCode = KeyCode.B;
                break;
            case "n":
            case "N":
                kCode = KeyCode.N;
                break;
            case "m":
            case "M":
                kCode = KeyCode.M;
                break;
            case "enter":
            case "Enter":
            case "ENTER":
                kCode = KeyCode.Return;
                break;
            case "LEFT":
            case "Left":
            case "left":
                kCode = KeyCode.LeftArrow;
                break;
            case "right":
            case "Right":
            case "RIGHT":
                kCode = KeyCode.RightArrow;
                break;
            case "up":
            case "Up":
            case "UP":
                kCode = KeyCode.UpArrow;
                break;
            case "down":
            case "Down":
            case "DOWN":
                kCode = KeyCode.DownArrow;
                break;
            case "shift":
            case "Shift":
            case "SHIFT":
                kCode = KeyCode.LeftShift;
                break;
            case "space":
            case "Space":
            case "SPACE":
                kCode = KeyCode.Space;
                break;
            case "escape":
            case "Escape":
            case "ESCAPE":
            case "esc":
            case "Esc":
            case "ESC":
                kCode = KeyCode.Escape;
                break;
            default:
                etr = false;
                break;
        }

        return etr;
    }

    private void CallGameFunctions()
    {
        if(createFunctionName != "")
        {
            switch(createFunctionName)
            {
                case "Body":
                    gameFunction.CreateBody(objectName, _1parami);
                    break;
                case "PlaneX":
                    gameFunction.CreatePlaneX(objectName, _1paramf);
                    break;
                case "PlaneY":
                    gameFunction.CreatePlaneY(objectName, _1paramf);
                    break;
                case "Square":
                    gameFunction.CreateSquare(objectName, _1paramf);
                    break;
                case "Circle":
                    gameFunction.CreateCircle(objectName, _1paramf);
                    break;
                case "CircleFill":
                    gameFunction.CreateCircleFill(objectName, _1paramf);
                    break;
                case "RainInstantiate":
                    gameFunction.RainInstantiate(objectName, _1parami, _2paramf, _3paramf);
                    break;
            }
        }
        else
        {
            switch (normalFunctionName)
            {
                case "SetPosition":
                    gameFunction.SetPosition(objectName, _1paramf, _2paramf);
                    break;
                case "SetLocalPosition":
                    gameFunction.SetLocalPosition(objectName, _1parami, _2paramf, _3paramf);
                    break;
                case "ColorAll":
                    gameFunction.ColorAll(objectName, _1paramc);
                    break;
                case "ColorChild":
                    gameFunction.ColorChild(objectName, _1parami, _2paramc);
                    break;
                case "Gravity":
                    gameFunction.Gravity(objectName, _1paramf);
                    break;
                case "BoxCollider":
                    gameFunction.BoxCollider(objectName, _1paramb);
                    break;
                case "CircleCollider":
                    gameFunction.CircleCollider(objectName, _1paramb);
                    break;
                case "SpeedX":
                    gameFunction.SpeedX(objectName, _1paramf, _2paramk, _3paramk);
                    break;
                case "SpeedY":
                    gameFunction.SpeedY(objectName, _1paramf, _2paramk, _3paramk);
                    break;
                case "SpeedXLoop":
                    gameFunction.SpeedXLoop(objectName, _1paramf);
                    break;
                case "SpeedYLoop":
                    gameFunction.SpeedYLoop(objectName, _1paramf);
                    break;
                case "Jumpforce":
                    gameFunction.Jumpforce(objectName, _1paramf, _2paramk);
                    break;
                case "Destroy":
                    gameFunction.Destroy(objectName);
                    break;
                case "MakeInvisible":
                    gameFunction.MakeInvisible(objectName, _1paramb);
                    break;
                case "Helpcfn":
                    gameFunction.Helpcfn();
                    break;
                case "Helpnfn":
                    gameFunction.Helpnfn();
                    break;
                case "DestroyInCollision":
                    gameFunction.DestroyInCollision(objectName, "rain", 1);
                    break;
            }
        }
    }
}
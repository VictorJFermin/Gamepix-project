using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowController : MonoBehaviour {

    private Camera mainCam;

    public GameObject scrollBar;
    
    private DialogManager dialogManager;
    private CodeManager codeManager;
    private ToolbarManager toolbar;
    public static string lastTheme = "midnight blue";

    void Awake()
    {
        mainCam = Camera.main;

        dialogManager = FindObjectOfType<DialogManager>();
        codeManager = FindObjectOfType<CodeManager>();
        toolbar = FindObjectOfType<ToolbarManager>();
    }

    void Start()
    {
        Default();
    }

    public void ShowHidePiro()
    {
        dialogManager.ToogleDialogBox();
    }

    public void Default()
    {
        Themes("midnight blue");
    }

    public void Themes(string name)
    {
        lastTheme = name;
        string cam = "";
        string ln = "";
        string pa = "";
        string fn = "";
        string nt = "";
        string sbA = "";
        string sbB = "";
        int db = 0;

        switch(name){
            case "black pastel":
                cam = ThemeColors.BLACKPASTEL_CAM;
                ln = ThemeColors.BLACKPASTEL_LINENUMBER;
                pa = ThemeColors.BLACKPASTEL_PARENTHESIS;
                fn = ThemeColors.BLACKPASTEL_FUNCTIONNAME;
                nt = ThemeColors.BLACKPASTEL_NORMALTEXT;
                sbA = ThemeColors.BLACKPASTEL_SCROLLBARAREA;
                sbB = ThemeColors.BLACKPASTEL_SCROLLBARBAR;
                db = ThemeColors.BLACKPASTEL_DIALOGBOXSPRITE;
                break;
            case "sublime text 2":
                cam = ThemeColors.SUBLIMETEXT2_CAM;
                ln = ThemeColors.SUBLIMETEXT2_LINENUMBER;
                pa = ThemeColors.SUBLIMETEXT2_PARENTHESIS;
                fn = ThemeColors.SUBLIMETEXT2_FUNCTIONNAME;
                nt = ThemeColors.SUBLIMETEXT2_NORMALTEXT;
                sbA = ThemeColors.SUBLIMETEXT2_SCROLLBARAREA;
                sbB = ThemeColors.SUBLIMETEXT2_SCROLLBARBAR;
                db = ThemeColors.SUBLIMETEXT2_DIALOGBOXSPRITE;             
                break;
            case "blueish":
                cam = ThemeColors.BLUEISH_CAM;
                ln = ThemeColors.BLUEISH_LINENUMBER;
                pa = ThemeColors.BLUEISH_PARENTHESIS;
                fn = ThemeColors.BLUEISH_FUNCTIONNAME;
                nt = ThemeColors.BLUEISH_NORMALTEXT;
                sbA = ThemeColors.BLUEISH_SCROLLBARAREA;
                sbB = ThemeColors.BLUEISH_SCROLLBARBAR;
                db = ThemeColors.BLUEISH_DIALOGBOXSPRITE;
                break;
            case "vime sc":
                cam = ThemeColors.VIMESC_CAM;
                ln = ThemeColors.VIMESC_LINENUMBER;
                pa = ThemeColors.VIMESC_PARENTHESIS;
                fn = ThemeColors.VIMESC_FUNCTIONNAME;
                nt = ThemeColors.VIMESC_NORMALTEXT;
                sbA = ThemeColors.VIMESC_SCROLLBARAREA;
                sbB = ThemeColors.VIMESC_SCROLLBARBAR;
                db = ThemeColors.VIMESC_DIALOGBOXSPRITE;
                break;
            case "back to school":
                cam = ThemeColors.BACKTOSCHOOL_CAM;
                ln = ThemeColors.BACKTOSCHOOL_LINENUMBER;
                pa = ThemeColors.BACKTOSCHOOL_PARENTHESIS;
                fn = ThemeColors.BACKTOSCHOOL_FUNCTIONNAME;
                nt = ThemeColors.BACKTOSCHOOL_NORMALTEXT;
                sbA = ThemeColors.BACKTOSCHOOL_SCROLLBARAREA;
                sbB = ThemeColors.BACKTOSCHOOL_SCROLLBARBAR;
                db = ThemeColors.BACKTOSCHOOL_DIALOGBOXSPRITE;
                break;
            case "terminal":
                cam = ThemeColors.TERMINAL_CAM;
                ln = ThemeColors.TERMINAL_LINENUMBER;
                pa = ThemeColors.TERMINAL_PARENTHESIS;
                fn = ThemeColors.TERMINAL_FUNCTIONNAME;
                nt = ThemeColors.TERMINAL_NORMALTEXT;
                sbA = ThemeColors.TERMINAL_SCROLLBARAREA;
                sbB = ThemeColors.TERMINAL_SCROLLBARBAR;
                db = ThemeColors.TERMINAL_DIALOGBOXSPRITE;
                break;
            case "sky blue":
                cam = ThemeColors.SKYBLUE_CAM;
                ln = ThemeColors.SKYBLUE_LINENUMBER;
                pa = ThemeColors.SKYBLUE_PARENTHESIS;
                fn = ThemeColors.SKYBLUE_FUNCTIONNAME;
                nt = ThemeColors.SKYBLUE_NORMALTEXT;
                sbA = ThemeColors.SKYBLUE_SCROLLBARAREA;
                sbB = ThemeColors.SKYBLUE_SCROLLBARBAR;
                db = ThemeColors.SKYBLUE_DIALOGBOXSPRITE;
                break;
            case "pink desktop":
                cam = ThemeColors.PINKDESKTOP_CAM;
                ln = ThemeColors.PINKDESKTOP_LINENUMBER;
                pa = ThemeColors.PINKDESKTOP_PARENTHESIS;
                fn = ThemeColors.PINKDESKTOP_FUNCTIONNAME;
                nt = ThemeColors.PINKDESKTOP_NORMALTEXT;
                sbA = ThemeColors.PINKDESKTOP_SCROLLBARAREA;
                sbB = ThemeColors.PINKDESKTOP_SCROLLBARBAR;
                db = ThemeColors.PINKDESKTOP_DIALOGBOXSPRITE;
                break;
            case "emacs green":
                cam = ThemeColors.EMACSGREEN_CAM;
                ln = ThemeColors.EMACSGREEN_LINENUMBER;
                pa = ThemeColors.EMACSGREEN_PARENTHESIS;
                fn = ThemeColors.EMACSGREEN_FUNCTIONNAME;
                nt = ThemeColors.EMACSGREEN_NORMALTEXT;
                sbA = ThemeColors.EMACSGREEN_SCROLLBARAREA;
                sbB = ThemeColors.EMACSGREEN_SCROLLBARBAR;
                db = ThemeColors.EMACSGREEN_DIALOGBOXSPRITE;
                break;
            case "orpah":
                cam = ThemeColors.ORPAH_CAM;
                ln = ThemeColors.ORPAH_LINENUMBER;
                pa = ThemeColors.ORPAH_PARENTHESIS;
                fn = ThemeColors.ORPAH_FUNCTIONNAME;
                nt = ThemeColors.ORPAH_NORMALTEXT;
                sbA = ThemeColors.ORPAH_SCROLLBARAREA;
                sbB = ThemeColors.ORPAH_SCROLLBARBAR;
                db = ThemeColors.ORPAH_DIALOGBOXSPRITE;
                break;
            case "chocolate liquor":
                cam = ThemeColors.CHOCOLATELIQUOR_CAM;
                ln = ThemeColors.CHOCOLATELIQUOR_LINENUMBER;
                pa = ThemeColors.CHOCOLATELIQUOR_PARENTHESIS;
                fn = ThemeColors.CHOCOLATELIQUOR_FUNCTIONNAME;
                nt = ThemeColors.CHOCOLATELIQUOR_NORMALTEXT;
                sbA = ThemeColors.CHOCOLATELIQUOR_SCROLLBARAREA;
                sbB = ThemeColors.CHOCOLATELIQUOR_SCROLLBARBAR;
                db = ThemeColors.CHOCOLATELIQUOR_DIALOGBOXSPRITE;
                break;
            case "bob murphy":
                cam = ThemeColors.BOBMURPHY_CAM;
                ln = ThemeColors.BOBMURPHY_LINENUMBER;
                pa = ThemeColors.BOBMURPHY_PARENTHESIS;
                fn = ThemeColors.BOBMURPHY_FUNCTIONNAME;
                nt = ThemeColors.BOBMURPHY_NORMALTEXT;
                sbA = ThemeColors.BOBMURPHY_SCROLLBARAREA;
                sbB = ThemeColors.BOBMURPHY_SCROLLBARBAR;
                db = ThemeColors.BOBMURPHY_DIALOGBOXSPRITE;
                break;
            case "midnight blue":
                cam = ThemeColors.MIDNIGHTBLUE_CAM;
                ln = ThemeColors.MIDNIGHTBLUE_LINENUMBER;
                pa = ThemeColors.MIDNIGHTBLUE_PARENTHESIS;
                fn = ThemeColors.MIDNIGHTBLUE_FUNCTIONNAME;
                nt = ThemeColors.MIDNIGHTBLUE_NORMALTEXT;
                sbA = ThemeColors.MIDNIGHTBLUE_SCROLLBARAREA;
                sbB = ThemeColors.MIDNIGHTBLUE_SCROLLBARBAR;
                db = ThemeColors.MIDNIGHTBLUE_DIALOGBOXSPRITE;
                break;
        }

        toolbar.Clear();

        Color camColor;
        Color sbAreaColor;
        Color sbBarColor;
        ColorUtility.TryParseHtmlString(cam, out camColor);
        ColorUtility.TryParseHtmlString(sbA, out sbAreaColor);
        ColorUtility.TryParseHtmlString(sbB, out sbBarColor);

        mainCam.backgroundColor = camColor;

        ColorBlock cb = scrollBar.GetComponent<Scrollbar>().colors;
        cb.normalColor = sbAreaColor;
        cb.highlightedColor = sbAreaColor;
        cb.pressedColor = sbAreaColor;
        scrollBar.GetComponent<Scrollbar>().colors = cb;
        scrollBar.GetComponent<Image>().color = sbBarColor;

        codeManager.UpdateCode(ln, pa, fn, nt);
        dialogManager.UpdateDialogBox(db);
        dialogManager.DialogSentence("You have chossen the theme " + name + " for GamePix, I hope you like it.", 1);
    }

    public static string GetLastTheme()
    {
        return lastTheme;
    }
}

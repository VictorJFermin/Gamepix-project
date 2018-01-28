using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    private ToolbarManager toolbar;
    private AudioSource audioS;

    public Sprite[] art;
    public AudioClip[] clips;
    public GameObject dialogBox;

    public Image piro;
    public Text text;

    void Awake()
    {
       toolbar = FindObjectOfType<ToolbarManager>();
       audioS = GetComponent<AudioSource>();
    }

    void Start ()
    {
        dialogBox.SetActive(true);
        piro.sprite = art[0];

        text.supportRichText = true;
        IntroSentence(false);
	}

    private void IntroSentence(bool isHide)
    {
        if (isHide)
            DialogSentence("Hey there, thanks for letting me help you, thats my goal. To help you as much as i can.", 0);
        else
            DialogSentence("Welcome to Gamepix, my name is Pyro and I will be your assistant while you create your game.If you do not want my help you can always turn me off in the Window Panel.", 0);

    }

    public void DialogSentence(string sentence, int sprite)
    {
        StopAllCoroutines();

        text.text = "";
        StartCoroutine(TypeSentence(sentence));
        piro.sprite = art[sprite];
    }

    public void DialogSentence(string sentence, string startSentence, int sprite)
    {
        StopAllCoroutines();

        text.text = startSentence;
        StartCoroutine(TypeSentence(sentence));
        piro.sprite = art[sprite];
    }

    IEnumerator TypeSentence (string sentence)
    {
        audioS.Play();
        foreach(char letter in sentence.ToCharArray())
        {
            text.text += letter;
            yield return null;
        }
        audioS.Stop();
    }

    public void ToogleDialogBox()
    {
        dialogBox.SetActive(!dialogBox.activeSelf);
        toolbar.Clear();
        if (dialogBox.activeSelf)
        {
            IntroSentence(true);
            piro.sprite = art[0];
        }
    }

    public void UpdateDialogBox(int db)
    {
        switch (db)
        {
            case 0:
                dialogBox.GetComponent<Image>().sprite = art[art.Length - 2];
                break;
            case 1:
                dialogBox.GetComponent<Image>().sprite = art[art.Length - 1];
                break;
        }
    }
}

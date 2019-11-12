using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueHandler : MonoBehaviour
{

    [Space]
    [Header("Textbox Objects")]
    public GameObject textbox;
    public TextMeshProUGUI _text;
    public Image img; // shows who's taalking
    public Sprite[] mySprites;

    [Space]
    [TextArea(2,5)] //more space to type lines
    public List<string> myLines;
    public int currentLine;
    public float textSpeed; // the closer to 0, the faster the speed

    [Space]
    [Header("Dialogue Runner Bools")]
    bool isTyping = false;
    bool cancelTyping = false;
    public bool isActive;// are things showing?
    public bool already; // did you press space already?

    SceneController sc;
    float timer; // to make sure the player doesn't accidentally skip text if the scene is loading

    // Use this for initialization
    void Start()
    {
        sc = FindObjectOfType<SceneController>();
        EnableTextBox();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (isActive && Input.anyKeyDown && timer > 0.3f)
        {
            if (already)
            {
                if (!isTyping) // if no text is typing go to next line OR disable textbox
                {
                    currentLine += 1;
                    if (currentLine >= myLines.Count)
                    {
                        DisableTextBox();
                    }
                    else
                    {
                        CheckCharacter();
                        StartCoroutine(Textscroll(myLines[currentLine]));
                    }
                }
                else if (isTyping && !cancelTyping) // cancel typing!
                {
                    cancelTyping = true;
                    already = false;
                }
            }
            else
            {
                already = true; // you pressed space already
            }
        }

    }

    private IEnumerator Textscroll(string lineoftext)
    {
        int letter = 0;
        _text.maxVisibleCharacters = 0;

        if(DoesContain("[name]"))
        {
            lineoftext = lineoftext.Replace("[name]", GameManager.gm.playerScore._name);
        }

        _text.text = lineoftext;

        isTyping = true;
        cancelTyping = false;

        while (isTyping && !cancelTyping && (letter < _text.text.Length - 1))
        {
            letter += 1;
            _text.maxVisibleCharacters = letter;
            yield return new WaitForSeconds(textSpeed);
        }

        _text.maxVisibleCharacters = _text.text.Length;
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableTextBox()
    {
        CheckCharacter();
        StartCoroutine(Textscroll(myLines[currentLine]));
        textbox.SetActive(true);
        isActive = true;
    }

    public void DisableTextBox()
    {
        already = false;
        isActive = false;
        textbox.SetActive(false);
        _text.text = "";
        if(sc.GetSceneName() == "Cutscene")
        {
            sc.WaitThenLoadWithTransition("TutorialScene", 0.5f, 0);
        }
    }

    public bool DoesContain(string theThing)
    {
        return myLines[currentLine].Contains(theThing);
    }

    public void CheckCharacter() // checks who to show
    {
        img.enabled = true; // by default set to enabled in case someone is talking

        if (DoesContain("Scientist:")) // if the scientist is talking
        {
            //change the image sprite to the scientist sprite
        }
        else // if no one is talking and it's just flavor text
        {
            img.enabled = false;
        }
    }
}

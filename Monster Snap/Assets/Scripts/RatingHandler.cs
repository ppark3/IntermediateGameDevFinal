using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RatingHandler : MonoBehaviour
{
    GameManager gm;
    DialogueHandler dh;
    public Image showingPhoto;
    public List<string> criticisms;
    public int currentPhoto; // which one are we critiquing?

    // Start is called before the first frame update
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        dh = FindObjectOfType<DialogueHandler>();

        SetUpDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dh.isActive)
        {
            if (currentPhoto < gm.ratedPhotos.Count)
            {
                SetUpDialogue();
            }
            else
            {
                SceneController.sC.LoadScene("HighScore Scene"); // going to hs scene with no loading temporarily >o>
            }
        }
    }
    List<string> CreateSentence(Photo.PhotoInstance p) // eventually we should change what this method is when we get scoring going!
    {
        List<string> sentences = new List<string>();

        if (p.nameOfMainMonster.ToLower() == "no monster")
        {
            sentences.Add("I can't clearly see a creature in this picture! No points!");
            return sentences;
        }

        // What's the name of the monster?
        sentences.Add("So this is a picture of " + p.nameOfMainMonster + ". ");

        // How close is it to the camera?

        switch (p.distanceScore)
        {
            case 100:
                sentences.Add("This creature is pretty far away so...100 points! ");
                break;
            case 200:
                sentences.Add("...You're almost at the perfect distance, but not quite. 200 points! ");
                break;
            case 500:
                sentences.Add("I can perfectly see this creature! 500 points! ");
                break;
        }



        // Are there extra creatures?

        if (p.monsters.Count > 1)
        {
            sentences.Add("Woah there are " + p.monsters.Count + " creatures in this photo! " + 20 * p.monsters.Count + " points! ");
        }
        // Is it in a specific pose!
        if (p.pose)
        {
            sentences.Add(p.nameOfMainMonster + p.poseString); 
        }

        // Is it centered?

        if (p.isInCenter)
        {
            sentences.Add(p.nameOfMainMonster + " is perfectly centered. Your score is getting doubled! ");
        }

        return sentences;
    }
    void SetUpDialogue()
    {
        dh.myLines = new List<string>();
        dh.currentLine = 0;
        showingPhoto.sprite = gm.TurnTextureIntoSprite(gm.ratedPhotos[currentPhoto].photoImage);
        dh.myLines = CreateSentence(gm.ratedPhotos[currentPhoto]);
        dh.EnableTextBox();
        currentPhoto++;
    }
}

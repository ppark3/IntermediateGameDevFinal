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
    // Start is called before the first frame update
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        dh = FindObjectOfType<DialogueHandler>();

        foreach(Photo.PhotoInstance p in gm.ratedPhotos)
        {
            criticisms.Add(CreateSentence(p));
        }
        SendToDialogueHandler();
    }

    // Update is called once per frame
    void Update()
    {
        if (dh.currentLine < gm.ratedPhotos.Count)
        {
            showingPhoto.sprite = gm.TurnTextureIntoSprite(gm.ratedPhotos[dh.currentLine].photoImage);
        }
        else
        {
            if (!dh.isActive)
            {
                SceneController.sC.LoadScene("HighScore Scene"); // going to hs scene with no loading temporarily >o>
            }
        }
    }

    string CreateSentence(Photo.PhotoInstance p) // eventually we should change what this method is when we get scoring going!
    {
        string sentence = "";

        if(p.nameOfMainMonster.ToLower() == "no monster")
        {
            return "I can't clearly see a creature in this picture! No points!";
        }

        // What's the name of the monster?
        sentence += "So this is a picture of " + p.nameOfMainMonster + ". ";

        // How close is it to the camera?

        switch(p.distanceScore)
        {
            case 100:
                sentence += "This creature is pretty far away so...100 points! ";
                break;
            case 200:
                sentence += "...You're almost at the perfect distance, but not quite. 200 points! ";
                break;
            case 500:
                sentence += "I can perfectly see this creature! 500 points! ";
                break;
        }

      

        // Are there extra creatures?

        if (p.monsters.Count > 1)
        {
            sentence += "Woah there are " + p.monsters.Count + " creatures in this photo! " + 20 * p.monsters.Count + " points! ";
        }
        // Is it in a specific pose!
        if (p.pose)
        {
            sentence += p.nameOfMainMonster + " is doing a cool pose! Bonus points! ";
        }

        // Is it centered?

        if (p.isInCenter)
        {
            sentence += p.nameOfMainMonster + " is perfectly centered. Your score is getting doubled! ";
        }

        return sentence;
    }


    void SendToDialogueHandler()
    {
        dh.myLines = criticisms;
    }
}

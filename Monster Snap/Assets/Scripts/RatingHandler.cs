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

        foreach(int num in gm.storedPhotoNums)
        {
            criticisms.Add(CreateSentence(num));
        }
        SendToDialogueHandler();
    }

    // Update is called once per frame
    void Update()
    {
        if (dh.currentLine < gm.storedPhotoNums.Count)
        {
            showingPhoto.sprite = gm.TurnTextureIntoSprite(gm.storedPhotos[gm.storedPhotoNums[dh.currentLine]].photoImage);
        }
        else
        {
            if (!dh.isActive)
            {
                SceneController.sC.LoadScene("HighScore Scene"); // going to hs scene with no loading temporarily >o>
            }
        }
    }

    string CreateSentence(int num) // eventually we should change what this method is when we get scoring going!
    {
        string sentence = "";

        if(gm.storedPhotos[num].nameOfMainMonster.ToLower() == " no monster")
        {
            return "There's no creatures in this picture! No points!";
        }

        // What's the name of the monster?
        sentence += "So this is a picture of " + gm.storedPhotos[num].nameOfMainMonster + ". ";

        // How close is it to the camera?

        switch(gm.storedPhotos[num].distanceScore)
        {
            case 100:
                sentence += "This creature is pretty far away so...100 points!";
                break;
            case 200:
                sentence += "...You're almost at the perfect distance, but not quite. 200 points!";
                break;
            case 500:
                sentence += "I can perfectly see this creature! 500 points!";
                break;
        }

      

        // Are there extra creatures?

        if (gm.storedPhotos[num].monsters.Count > 1)
        {
            sentence += "Woah there are " + gm.storedPhotos[num].monsters.Count + " creatures in this photo! " + 20 * gm.storedPhotos[num].monsters.Count + " points! ";
        }
        // Is it in a specific pose!
        if (gm.storedPhotos[num].pose)
        {
            sentence += gm.storedPhotos[num].nameOfMainMonster + " is doing a cool pose! Bonus points! ";
        }

        // Is it centered?

        if (gm.storedPhotos[num].isInCenter)
        {
            sentence += gm.storedPhotos[num].nameOfMainMonster + " is perfectly centered. Your score is getting doubled! ";
        }

        return sentence;
    }


    void SendToDialogueHandler()
    {
        dh.myLines = criticisms;
    }
}

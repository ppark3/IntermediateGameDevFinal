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
            showingPhoto.sprite = gm.TurnTextureIntoSprite(gm.storedPhotos[gm.storedPhotoNums[dh.currentLine]]);
        }
    }

    string CreateSentence(int num) // eventually we should change what this method is when we get scoring going!
    {
        return "Wow! This is photo number " + num + "!";
    }


    void SendToDialogueHandler()
    {
        dh.myLines = criticisms;
    }
}

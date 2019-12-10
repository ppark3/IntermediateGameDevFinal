using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PhotoCountDown : MonoBehaviour
{
    PhotoGalleryManager pgm;
    SceneController sc;
    GameManager gm;
    public TextMeshProUGUI _text;
    public int amtLeft; // amount of photos you need to choose before proceeding
    public int totalPhotosTaken;

    // Start is called before the first frame update
    void Start()
    {
        pgm = FindObjectOfType<PhotoGalleryManager>();
        gm = FindObjectOfType<GameManager>();
        sc = FindObjectOfType<SceneController>();
        _text = GetComponent<TextMeshProUGUI>();

        totalPhotosTaken = gm.storedPhotos.Count;
        if(totalPhotosTaken < 10)
        {
            if (totalPhotosTaken > 2)
            {
                amtLeft = totalPhotosTaken - 2;
            }
            else
            {
                amtLeft = totalPhotosTaken; // unfortunately if the player only takes like 1 or 2 pictures they have to choose whatevers there
            }
        }
        else if(totalPhotosTaken == 10) // we don't want the player to feel this choice is unecessary, so..
        {
            amtLeft = 8; // let's give them less to choose from maybe?
        }
        else
        {
            amtLeft = 10; // if the player has more than 10, even if it's 11 photos, they have to make that choice to choose one over another
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(amtLeft == 0)
        {
            pgm.FinishGallery();
        }

        _text.text = "You have to choose " + amtLeft + " more photo(s) to show your boss!";
    }
}

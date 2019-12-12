using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoBehaviour : MonoBehaviour
{
    PhotoCountDown pcd; // no longer in use
    PhotoGalleryManager pgm;
    PlaySoundEffect pse;

    public Photo.PhotoInstance myPhoto;

    //public int myPhotoNum; // where is this photo in the list?
    Image img;

    private void Start()
    {
        pse = transform.parent.GetComponent<PlaySoundEffect>();
        img = GetComponent<Image>();
        pgm = FindObjectOfType<PhotoGalleryManager>();
        //pcd = FindObjectOfType<PhotoCountDown>();
    }

    // Start is called before the first frame update
    void Update()
    {


    }


    //if you choose a photo...
    public void ChoosePhoto()
    {
        pse.PlaySFX(0);

        GameManager.gm.playerScore._num += myPhoto.finalScore; // adding a score to the player's score
        GameManager.gm.ratedPhotos.Add(myPhoto); // store this photo number into a list!

        pgm.monsterTracker++;
        pgm.GetNewPhotos();
    }

}

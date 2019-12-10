using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoBehaviour : MonoBehaviour
{
    PhotoCountDown pcd; // no longer in use
    PhotoGalleryManager pgm;
    public int myPhotoNum; // where is this photo in the list?
    Image img;

    private void Start()
    {
        img = GetComponent<Image>();
        pgm = FindObjectOfType<PhotoGalleryManager>();
        //pcd = FindObjectOfType<PhotoCountDown>();
    }

    // Start is called before the first frame update
    void Update()
    {


        if(isInChosenList()) // if the photo was chosen already...
        {
            img.color = Color.gray;
        }
        else // if the photo wasn't chosen yet!
        {
            img.color = Color.white;
        }
    }


    public void FindMyPhotoNum()
    {
        int tracker = 0;
        foreach (Photo.PhotoInstance p in GameManager.gm.storedPhotos)
        {
            if(img.sprite == GameManager.gm.TurnTextureIntoSprite(p.photoImage))
            {
                myPhotoNum = tracker;
                return;
            }
            tracker++;
        }
    }


    //if you choose a photo...
    public void ChoosePhoto()
    {

        if (isInChosenList())
        {
            DeselectPhoto();
            return;
        }
        GameManager.gm.playerScore._num += GameManager.gm.storedPhotos[myPhotoNum].finalScore; // adding a score to the player's score
        GameManager.gm.storedPhotoNums.Add(myPhotoNum); // store this photo number into a list!

        pgm.monsterTracker++;
        pgm.GetNewPhotos();
    }

    //if you deselect the photo... NOTE: YOU CAN NO LONGER DO THIS IN THE NEWER VERSION
    public void DeselectPhoto()
    {
        pcd.amtLeft++; // you have more photos to choose from
        GameManager.gm.playerScore._num -= GameManager.gm.storedPhotos[myPhotoNum].finalScore; // subtracting a score to the 
        GameManager.gm.storedPhotoNums.Remove(myPhotoNum); // store this photo number into a list!
    }

    bool isInChosenList() // checks if the photo number matches one in the list
    {
        foreach(int num in GameManager.gm.storedPhotoNums)
        {
            if(num == myPhotoNum)
            {
                return true;
            }
        }
        return false;
    }
}

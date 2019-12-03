using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoBehaviour : MonoBehaviour
{
    PhotoCountDown pcd;
    public int myPhotoNum; // where is this photo in the list?


    private void Start()
    {
        pcd = FindObjectOfType<PhotoCountDown>();
    }

    // Start is called before the first frame update
    void Update()
    {


        if(isInChosenList()) // if the photo was chosen already...
        {
            GetComponent<Image>().color = Color.gray;
        }
        else // if the photo wasn't chosen yet!
        {
            GetComponent<Image>().color = Color.white;
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
        pcd.amtLeft--; // you have less photos to choose from
    }

    //if you deselect the photo... NOTE: THIS IS NOT IMPLEMENTED YET
    public void DeselectPhoto()
    {
        pcd.amtLeft++; // you have more photos to choose from
        GameManager.gm.playerScore._num -= GameManager.gm.storedPhotos[myPhotoNum].finalScore; // adding a score to the 
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

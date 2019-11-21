using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoBehaviour : MonoBehaviour
{
    //TO DO: have criteria for if you can submit your photos to "professor oak" or not lmao
    //Also make it so you can de-select a photo!

    public int myPhotoNum; // where is this photo in the list?

    // Start is called before the first frame update
    void Update()
    {
        if(isInChosenList() // if the photo was chosen already...
        {
            GetComponent<Button>().interactable = false;
        }
        else // if the photo wasn't chosen yet!
        {
            GetComponent<Button>().interactable = true;
        }
    }

    //if you choose a photo
    public void ChoosePhoto()
    {
        GameManager.gm.storedPhotoNums.Add(myPhotoNum); // store this photo number into a list!
        GetComponent<Button>().interactable = false; // now you can't interact with this photo
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

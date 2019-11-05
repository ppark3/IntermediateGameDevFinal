using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoBehaviour : MonoBehaviour
{
    //TO DO: have criteria for if you can submit your photos to "professor oak" or not lmao

    public int myPhotoNum; // where is this photo in the list?

    // Start is called before the first frame update
    void Update()
    {
        if(isInChosenList())
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void ChoosePhoto()
    {
        GameManager.gm.storedPhotoNums.Add(myPhotoNum);
        GetComponent<Button>().interactable = false;
    }


    bool isInChosenList()
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

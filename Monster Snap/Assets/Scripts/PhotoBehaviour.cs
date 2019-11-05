using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoBehaviour : MonoBehaviour
{
    //TO DO: have criteria for if you can submit your photos to "professor oak" or not lmao

    bool isSelectable =  true;
    public int myPhotoNum; // where is this photo in the list?

    // Start is called before the first frame update
    void Start()
    {
        if(!isSelectable)
        {
            GetComponent<Button>().interactable = false;
        }
    }

    public void ChoosePhoto()
    {
        GameManager.gm.storedPhotoNums.Add(myPhotoNum);
        isSelectable = false;
    }

}

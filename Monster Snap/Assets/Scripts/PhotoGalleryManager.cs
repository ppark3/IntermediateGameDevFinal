using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoGalleryManager : MonoBehaviour
{
    int currentPage; // each page shows four photos. Depending on the page it'll show different photos

    public GameObject photoPrefab;
    public List<Image> shownPhotos;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    void ShowPhotos()
    {
        for (int i = 0; i < 4; i++)
        {

        }
    }

    //function used if the player clicks the left arrow for the photos
    public void GoLeft()
    {

    }

    //function used if the player clicks the right arrow for photos
    public void GoRight()
    {

    }
   
}

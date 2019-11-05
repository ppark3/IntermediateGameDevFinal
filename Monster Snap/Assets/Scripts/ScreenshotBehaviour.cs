﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotBehaviour : MonoBehaviour // this script should be attached to a camera according to unity docs
{

    public KeyCode pictureButton;
    public List<Texture2D> screenshots; // list of textures that will be our screenshots

    public GameObject imagePrefab; //prefab containg an image popup of ur photo!
    public Renderer renderer; // the renderer of the image showing the new screenshot!
    public Vector3 imageSpawnpos; // where is our new photo popping up?
    bool canTakePicture;

    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        screenshots = new List<Texture2D>(); //initializing list
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pictureButton) && !canTakePicture)
        {
            canTakePicture = true;
        }
    }

    // " Will be called from camera after regular rendering is done. "
    private void OnPostRender()
    {
        if (canTakePicture)
        {
            Texture2D newTexture; // here's the new texture we're about to add to our list of screenshots
            newTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false); // getting screenshot by getting screen width/height and colord
            newTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false); // reading all the pictures on the screen to be stored for our screenshot
            newTexture.Apply(); // making sure that texture is UP TO DATE!
            screenshots.Add(newTexture); // adding texture to list of screenshots!

            ShowNewPhotoOnCanvas(newTexture);
           
            canTakePicture = false;
        }
    }

    //function
    private void ShowNewPhotoOnCanvas(Texture2D newTexture)
    {
        //the below line creates a sprite out of the texture we have so it can be shown on a canvas
        img.sprite = Sprite.Create(newTexture, new Rect(0.0f, 0.0f, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        img.GetComponent<Animator>().Play(0); // plays the animation for the image to fade in and out

    }


    //function that creates a new gameobject to show what image we took and destroys it after 3 seconds
    private void ShowNewPhoto(Texture2D texture)
    {
        GameObject newPhoto = Instantiate(imagePrefab, transform);// show new photo
        renderer = newPhoto.GetComponent<Renderer>();// get new photos renderer
        renderer.material.mainTexture = texture; // make the new photo actually have the screenshot
        Destroy(newPhoto, 2f); //destroy photo after one second
    }
}
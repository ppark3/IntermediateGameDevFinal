using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhotoPrompter : MonoBehaviour // This script prompts the player to pick a photo
{
    TextMeshProUGUI _text;
    GameManager gm;
    PhotoGalleryManager pgm;

    // Start is called before the first frame update
    void Start()
    {
        pgm = FindObjectOfType<PhotoGalleryManager>();
        gm = FindObjectOfType<GameManager>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pgm.monsterTracker < gm.monstersInPhotos.Count)
        {
            _text.text = "Choose your best photo of" + gm.monstersInPhotos[pgm.monsterTracker] + "!";
        }
    }
}

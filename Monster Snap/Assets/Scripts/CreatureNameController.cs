using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreatureNameController : MonoBehaviour
{
    public TMP_InputField input;
    GameManager gm;

    public List<string> monstersToBeNamed;
    public int posInList;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>(); // storing it as gm here so we can reference it in a quicker/shorter way >o>
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function that runs when a player hits enter after typing what they want in the text input field
    public void SaveName()
    {
        ChangeAllMonstersNames(input.text);
        //
    }

    //functioning to run through and check every photo with the same tag and make it this new name
    void ChangeAllMonstersNames(string newName)
    {

    }

    void StoreMonstersToBeNamed()
    {
        monstersToBeNamed = new List<string>();
        foreach(Photo.PhotoInstance p in gm.storedPhotos)
        {

        }
    }
}

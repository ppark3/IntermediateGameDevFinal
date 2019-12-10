using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class CreatureNameController : MonoBehaviour
{
    public TMP_InputField input;
    GameManager gm;

    public List<string> monstersToBeNamed;
    public List<int> numsOfNamedMonsters;
    public int posInList;

    public Image monsterImage;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>(); // storing it as gm here so we can reference it in a quicker/shorter way >o>
        StoreMonstersToBeNamed();
        ShowCurrentMonsters();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //function that runs when a player hits enter after typing what they want in the text input field
    public void SaveName()
    {
        ChangeAllMonstersNames(input.text);
        EventSystem e = FindObjectOfType<EventSystem>();
        input.text = "";
        e.SetSelectedGameObject(input.gameObject);
    }

    void ShowCurrentMonsters()
    {
        monsterImage.sprite = gm.TurnTextureIntoSprite(gm.storedPhotos[numsOfNamedMonsters[posInList]].photoImage);
    }

    //functioning to run through and check every photo with the same tag and make it this new name
    void ChangeAllMonstersNames(string newName)
    {
        foreach (Photo.PhotoInstance p in gm.storedPhotos)
        {
            if (monstersToBeNamed[posInList] == p.nameOfMainMonster)
            {
                p.nameOfMainMonster = newName;
            }
        }
        gm.monstersInPhotos.Add(newName);
        posInList++;
        if (posInList >= monstersToBeNamed.Count)
        {
            SceneController.sC.LoadScene("GalleryScene");
            return;
        }
        ShowCurrentMonsters();
    }
    void StoreMonstersToBeNamed()
    {
        gm.monstersInPhotos = new List<string>();
        int tracker = 0;
        numsOfNamedMonsters = new List<int>();
        monstersToBeNamed = new List<string>();
        foreach (Photo.PhotoInstance p in gm.storedPhotos)
        {
            if (!monstersToBeNamed.Contains(p.nameOfMainMonster))
            {
                if (p.nameOfMainMonster != "no monster")
                {
                    numsOfNamedMonsters.Add(tracker);
                    monstersToBeNamed.Add(p.nameOfMainMonster);
                }
            }
            tracker++;
        }
    }
}

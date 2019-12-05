using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NamePrompter : MonoBehaviour // works with creature name controller to prompt the player to name each creature
{
    CreatureNameController cnc;
    TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        cnc = FindObjectOfType<CreatureNameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cnc.monstersToBeNamed.Count > cnc.posInList)
        {
            _text.text = "Give this " + cnc.monstersToBeNamed[cnc.posInList] + " a name!";
        }
    }
}

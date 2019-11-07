using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameGetter : MonoBehaviour // this script receives the name the user puts into the input field
{

    TMP_InputField _if; // the input field

    // Start is called before the first frame update
    void Start()
    {
        _if = GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneController.sC.currentScene == 1) // if we are in the naming player scene....
        {
            GameManager.gm.playerScore._name = _if.text; //take the text that the player inputs and make it the player name
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            OnFinish();
        }
    }

    void OnFinish()
    {
        if (SceneController.sC.currentScene == 1) // if we are in the naming player scene....
        {
            SceneController.sC.WaitThenLoadWithTransition(2,0.5f,0); // go to the next scene ( cutscene )
        }
    }
}

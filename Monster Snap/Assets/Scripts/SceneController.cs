using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour // script should be on the game manager so it isn't destroyed/duplicated
{
    public int currentScene;

    public static SceneController sC;
    TransitionController tc;

    public float timer; // timer for having a pause between scene changes
    public bool timerIsOn; // bool to turn on timer
    bool didStoreNum; // are we storing a scene number to change to?
    bool didStoreName; // are we storing a scene name to change to?

    public string storedName;
    public int storedNum;


    // Start is called before the first frame update
    void Start()
    {
        tc = FindObjectOfType<TransitionController>(); 
        sC = this;

        timerIsOn = true;
        timer = 0.5f;
    }


    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        //CHEATS
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                BackAScene();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                ForwardAScene();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetScene();
            }
        }

        if (currentScene == 0)
        {
            if (Input.anyKeyDown && timerIsOn == false) // if statement to stop people from accidentally skipping the start scene
            {
                //here, we are going to the character select scene after 0.5 seconds and fading to black whilst loading
                WaitThenLoadWithTransition(1, 0.5f, 0);
            }
        }
        if (GetSceneName() == "TutorialScene" && Input.GetKeyDown(KeyCode.J)) // if statement for proceeding past the tutorial
        {
            WaitThenLoadWithTransition("CourseGameplay", 0.5f, 2);
        }


        if (timerIsOn) // if statement to run the timer and change the scene
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                if (!didStoreNum && !didStoreName)
                {
                    timerIsOn = false;
                }
                else
                {
                    if (didStoreName)
                    {
                        LoadScene(storedName);
                    }
                    if (didStoreNum)
                    {
                        LoadScene(storedNum);
                    }
                    didStoreNum = false;
                    didStoreName = false;
                }
            }
        }
    }

    public string GetSceneName() // get the name of the current scene
    {
        return SceneManager.GetActiveScene().name;
    }

    public void BackAScene() //when you wanna go back one scene
    {
        if (currentScene != 0) // makes sure we can't go in the negatives
        {
            currentScene -= 1;
            LoadScene(currentScene);
        }
    }
    public void ForwardAScene() //when you wanna go forward one scene
    {
        if (currentScene != SceneManager.sceneCountInBuildSettings - 1) // make sure we can't go past the max number of scenes there
        {
            currentScene += 1;
            LoadScene(currentScene);
        }
    }
    public void ResetScene() // resets scene
    {
        LoadScene(currentScene);

    }

    public void LoadScene(int num) // loads scene based on number
    {
        SceneManager.LoadScene(num);
    }

    public void LoadScene(string sName) // loads scene based on name
    {
        SceneManager.LoadScene(sName);
    }

    public void WaitThenLoad(string sName, float time) // loads scene based on name and waits before switching
    {
        didStoreName = true;
        timerIsOn = true;
        timer = time;
        storedName = sName;
    }

    public void WaitThenLoadWithTransition(string sName, float time, int whichTransition) // loads scene with a timer and a nice transition
    {
        didStoreName = true;
        timerIsOn = true;
        timer = time;
        storedName = sName;
        tc.anim.enabled = true;
        tc.PlayTransiton(whichTransition);
        // Current transitions are
        // 0 fade black, 1 fade white, 2 screen in screen out

    }

    public void WaitThenLoad(int sNum, float time)
    {
        didStoreNum = true;
        timerIsOn = true;
        timer = time;
        storedNum = sNum;
    }

    public void WaitThenLoadWithTransition(int sNum, float time, int whichTransition)
    {
        didStoreNum = true;
        timerIsOn = true;
        timer = time;
        storedNum = sNum;
        tc.anim.enabled = true;
        tc.PlayTransiton(whichTransition);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour // script should be on the game manager so it isn't destroyed/duplicated
{
    public int currentScene;

    public static SceneController sC;
    TransitionController tc;

    public float timer;
    public bool timerIsOn;
    bool didStoreNum;
    bool didStoreName;

    public string storedName;
    public int storedNum;


    // Start is called before the first frame update
    void Start()
    {
        tc = FindObjectOfType<TransitionController>(); // transition controller should be within the GameManager in the scene
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
            if (Input.anyKeyDown && timerIsOn == false)
            {
                //here, we are going to the character select scene after 0.5 seconds and fading to black whilst loading
                WaitThenLoadWithTransition(1, 0.5f, 0);
            }
        }
        if (GetSceneName() == "TutorialScene" && Input.GetKeyDown(KeyCode.J))
        {
            WaitThenLoadWithTransition("CourseGameplay", 0.5f, 2);
        }


        if (timerIsOn)
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

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void BackAScene() //when you wanna go back one scene
    {
        if (currentScene != 0)
        {
            currentScene -= 1;
            LoadScene(currentScene);
        }
    }
    public void ForwardAScene() //when you wanna go forward one scene
    {
        if (currentScene != SceneManager.sceneCountInBuildSettings - 1)
        {
            currentScene += 1;
            LoadScene(currentScene);
        }
    }
    public void ResetScene()
    {

        LoadScene(currentScene);

    }

    public void LoadScene(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void LoadScene(string sName)
    {
        SceneManager.LoadScene(sName);
    }

    public void WaitThenLoad(string sName, float time)
    {
        didStoreName = true;
        timerIsOn = true;
        timer = time;
        storedName = sName;
    }

    public void WaitThenLoadWithTransition(string sName, float time, int whichTransition)
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

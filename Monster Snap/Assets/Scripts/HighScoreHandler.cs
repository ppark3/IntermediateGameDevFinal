using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreHandler : MonoBehaviour
{
    string jsonString;
    public List<HighScore> highScores;
    bool dataDoneLoading;
    bool readyToDisplay; //is everything loaded and ready to go?

    public TextMeshProUGUI[] _nameObjects; // texts showing names
    public TextMeshProUGUI[] _scoreObjects; //texts showing scores

    public HighScore fakeScore;

    string filePathData = Path.Combine(Application.streamingAssetsPath, "highScores.json"); // where are we saving this data?

    // Start is called before the first frame update
    void Start()
    {
        highScores = new List<HighScore>();
        highScores.Add(fakeScore);
        LoadHighScores();
    }

    private void Update()
    {
       if(dataDoneLoading)
        {
            checkForNewHS(GameManager.gm.playerScore._num);
            dataDoneLoading = false;
        }
       if(readyToDisplay)
        {
            ShowScores();
            readyToDisplay = false;
        }
    }

    public void checkForNewHS(int newScore) // this function should only run if data done loading
    {
        foreach (HighScore h in highScores.ToArray())
        {
            if (h._num < newScore)
            {
                highScores.Add(GameManager.gm.playerScore);
                break;
            }
        }
        highScores.Sort(SortByScore);

        readyToDisplay = true;
    }

    int SortByScore(HighScore scoreOne, HighScore scoreTwo)
    {
        return scoreTwo._num.CompareTo(scoreOne._num);
    }


    void ShowScores() // this function should only run if ready to display is true
    {
        for (int i = 0; i < _nameObjects.Length;i++)
        {
            if(i < highScores.Count)
            {
                _nameObjects[i].text = highScores[i]._name;
                _scoreObjects[i].text = highScores[i]._num.ToString();
            }
            else
            {
                _nameObjects[i].enabled = false;
                _scoreObjects[i].enabled = false;
            }
        }
        SaveHighScores();
    }

    public void SaveHighScores()
    {
        ScoreData sd = new ScoreData();
        sd.scores = new List<HighScore>();

        foreach (HighScore score in highScores)
        {
            sd.scores.Add(score);
        }

        jsonString = JsonUtility.ToJson(sd, true);
       

        if (!File.Exists(filePathData))
        {
            FileStream f = File.Create(filePathData);
            f.Close();
        }

        File.WriteAllText(filePathData, jsonString);

    }

    public void LoadHighScores()
    {

#if UNITY_EDITOR || UNITY_IOS || UNITY_STANDALONE || UNITY_STANDALONE_OSX

        if (File.Exists(filePathData))
        {
            jsonString = File.ReadAllText(filePathData);
            ScoreData data = JsonUtility.FromJson<ScoreData>(jsonString); //convert Data from JSON   
            this.highScores = data.scores;
            dataDoneLoading = true;
        }
        else
        {
            SaveHighScores();
            dataDoneLoading = true;
        }

#elif UNITY_ANDROID || UNITY_WEBGL
            StartCoroutine(LoadDifferentStreamingAssets(filePathData));
#endif
    }

    private IEnumerator LoadDifferentStreamingAssets(string fileName)
    {

        UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(fileName);
        www.downloadHandler = new UnityEngine.Networking.DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            jsonString = www.downloadHandler.text;
        }
        ScoreData data = JsonUtility.FromJson<ScoreData>(jsonString); //convert Data from JSON   
        this.highScores = data.scores;
        dataDoneLoading = true;

    }

    class ScoreData
    {
        public List<HighScore> scores;
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreHandler : MonoBehaviour
{
    public List<HighScore> highScores;
    // Start is called before the first frame update
    void Start()
    {
        highScores = new List<HighScore>();
    }

    public bool isNewHighScore(int newScore)
    {
        foreach (HighScore h in highScores)
        {
            if(h._num < newScore)
            {
                return true;
            }
        }
        return false;
    }
}

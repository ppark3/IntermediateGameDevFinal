using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo : MonoBehaviour
{
    [System.Serializable]
    public class PhotoInstance
    {
        public Texture2D photoImage; // Actual screenshot
        public List<MonsterScript> monsters; // list of monsters in the photo
        public string nameOfMainMonster; // name ( tag moreso) of the monster we are getting

        public int finalScore; // the total score for this photo!

        public int distanceScore; // the score you get based on distance
        public bool positionScore; // the score you get based on how close the main monster is in the middle
        public int numberOfExtras; // number of the same monster in the photo! ( you get bonus points)
        public bool pose; // bool checking if the monster is doing a cool pose

        public PhotoInstance()
        {
            photoImage = null;
            monsters = new List<MonsterScript>();
            finalScore = 0;
        }

        public void PickMainMonster()
        {
            if (monsters.Count == 1)
            {
                nameOfMainMonster = monsters[0].tag;
            }
            else if (monsters.Count == 0)
            {
                nameOfMainMonster = "No Monster";
            }
            else
            {
                MonsterScript mainMon = monsters[0];
                for (int i = 1; i < monsters.Count; i++)
                {
                    if (monsters[i]._distance < mainMon._distance && monsters[i]._position < mainMon._position)
                    {
                        mainMon = monsters[i];
                    }
                }
            }
        }

        public void CalculateScore()
        {
            int temporaryFinalScore = 0;

            // double if in the center, else add additional points

            // for size, it's more if distance is smaller... but also, if it's too close, you get less points, so pick a nice medium!

            // I don't think we need to focus on giving points based on there being multiple monsters in a photo yet, though so don't sweat it!

            finalScore = temporaryFinalScore;
        }
    }
}

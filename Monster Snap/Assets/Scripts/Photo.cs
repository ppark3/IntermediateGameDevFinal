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
        MonsterScript mainMonster; // the main monster we're refrencing for points
        public string nameOfMainMonster; // name ( tag moreso) of the monster we are getting

        public int finalScore; // the total score for this photo!

        public int distanceScore; // the score you get based on distance
        public bool isInCenter; // doubles score if the monster was in the center of the photo
        public int extrasScore; // number of the same monster in the photo! ( you get bonus points)
        public bool pose; // bool checking if the monster is doing a cool pose

        public PhotoInstance() // constructor for when a Photo Instance is created
        {
            photoImage = null; // sets screenshot to nothing
            monsters = new List<MonsterScript>(); // initializes monsters list
            finalScore = 0; // default score is 0
        }

        //changes the string for MainMonster based on how many monsters are here and they're distance
        public void PickMainMonster()
        {
            if (monsters.Count == 1) // if there's only one monster, that's the main monster!
            {
                mainMonster = monsters[0];
                nameOfMainMonster = monsters[0].tag;
            }
            else if (monsters.Count == 0) // if there's no monsters, there's no main monster!
            {
                nameOfMainMonster = "no monster";
            }
            else
            {
                nameOfMainMonster = monsters[0].tag;
                mainMonster = monsters[0]; // sets the first monster as the main one by default
                for (int i = 1; i < monsters.Count; i++) // loops through each monster in the photo
                {
                    if (monsters[i]._distance < mainMonster._distance && monsters[i]._position < mainMonster._position) // checks if their distance/position is better than the default
                    {
                        mainMonster = monsters[i]; // sets the best creature as the main one
                    }
                }
            }
        }

        //this function calculates all of the scores the Photo Instance class has
        public void CalculateScore()
        {
            if(mainMonster == null) // if there's no monster in the photo, go back!!!
            {
                return;
            }


            // Here we're calculating the score based on the distance between the creature and the camera
            if (mainMonster._distance > 8)
            {
                distanceScore = 100;
            }
            else if (mainMonster._distance < 8 && mainMonster._distance > 5)
            {
                distanceScore = 200;
            }
            else if (mainMonster._distance < 5 && mainMonster._distance > 2)
            {
                distanceScore = 500;
            }
            else if (mainMonster._distance < 2)
            {
                distanceScore = 200;
            }

            // giving an extra +20 points if other monsters are in the photo
            if (monsters.Count > 1)
            {
                foreach (MonsterScript mon in monsters)
                {
                    extrasScore += 20;
                }
            }

            // Bonus points if the creature is doing a special thing
            if(mainMonster.isDoingSpecialAction)
            {
                extrasScore += 70;
            }


            finalScore = extrasScore + distanceScore;

            // Here we're doubling the score if the player has the creature in the center!
            if (mainMonster._position < 0.2)
            {
                finalScore *= 2;
                isInCenter = true;
            }
        }
    }
}

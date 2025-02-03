using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Esc : MonoBehaviour
{
    public ScoreObject scoreObject;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            scoreObject.setScore(0f);
            scoreObject.setScoreTemp(0f);
            scoreObject.levelIndex = 0;
            Application.Quit();
        }
    }
}
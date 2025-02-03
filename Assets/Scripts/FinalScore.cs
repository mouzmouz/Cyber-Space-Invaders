using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private Text score;
    [SerializeField] private bool failed;
    public ScoreObject scoreObject;

    // Update is called once per frame
    private void Start()
    {
        if (failed)
        {
            score.text = "Final Score: " + scoreObject.getScoreTemp().ToString();
        }
        else
        {
            score.text = "Final Score: " + scoreObject.getScore().ToString();
        }
    }
}

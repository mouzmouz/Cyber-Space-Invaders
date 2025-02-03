using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreObject", menuName = "Scriptable Objects", order = 1)]
public class ScoreObject : ScriptableObject
{
    [SerializeField] private double totalScore;
    [SerializeField] private double totalScoreTemp;
    public int levelIndex;
    public void setScore(double objectScore)
    {
        totalScore = objectScore;
    }
    public void setScoreTemp(double objectScore)
    {
        totalScoreTemp = objectScore;
    }
    public double getScore()
    {
        return totalScore;
    }
    public double getScoreTemp()
    {
        return totalScoreTemp;
    }
}

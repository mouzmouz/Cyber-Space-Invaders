using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private ScoreObject scoreObject;
    void Update()
    {
        print(Input.acceleration.y);
        if (Input.acceleration.y > 0f)
        {
            print(Input.acceleration.y);
            SceneManager.LoadScene(scoreObject.levelIndex);
        }
    }
}

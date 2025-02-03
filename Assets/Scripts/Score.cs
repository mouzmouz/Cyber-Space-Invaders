using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Text score;
    [SerializeField] private Text ammo;

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + player.GetComponent<PlayerManager>().getScore().ToString();
        ammo.text = "Ammo: " + player.GetComponent<PlayerManager>().ammo;
    }
}

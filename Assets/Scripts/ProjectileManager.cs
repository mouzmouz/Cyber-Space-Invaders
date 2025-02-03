using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileManager : MonoBehaviour
{
    private FindTarget script;
    [SerializeField] private GameObject player;
    private void Start()
    {
        script = player.GetComponentInChildren<FindTarget>();
    }
    public void onProjectileHit()
    {
        script.setCanShoot(true);
    }
}

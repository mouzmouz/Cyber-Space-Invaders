using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTarget : MonoBehaviour
{
    private PlayerManager playerVehicleManager;
    [SerializeField] float range;
    [SerializeField] private bool canShoot = true;

    private void Start()
    {
        playerVehicleManager = gameObject.GetComponentInParent<PlayerManager>();
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        bool ray = Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), out hit, range);
        //Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * range, Color.green);
        if (ray)
        {
            if (hit.transform.gameObject.CompareTag("Breakable")&&canShoot&&playerVehicleManager.ammo>0)
            {
                print("Hit breakable");
                playerVehicleManager.Shoot(hit.point);
                canShoot = false;
            }
        }
    }

    public void setCanShoot(bool flag)
    {
        canShoot = flag;
    }
}

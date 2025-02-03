using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private UnityEvent bulletHit;
    // Start is called before the first frame update
    private void OnDestroy()
    {
        bulletHit.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("TRIGGERED");
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Breakable"))
        {
            Destroy(gameObject);
        }
    }
}

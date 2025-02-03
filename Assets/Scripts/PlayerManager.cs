using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class PlayerManager : MonoBehaviour
{

	// This is a reference to the Rigidbody component called "rb"
	public Rigidbody rb;

	public float forwardForce = 2000f;  // Variable that determines the forward force
	private float forwardForceAdded = 0f;
	public float sidewaysForce = 500f;  // Variable that determines the sideways force
	public float jumpForce = 500f; // Variable that determines the jump force
	public float speedLimit = 100f;
	private int jumpInput = 0;
	[SerializeField] private bool onFloor;
	public int ammo = 0;
	private double score;
	private double lastPos;
	[SerializeField] private GameObject bullet;
	public ScoreObject scoreObject;
	[SerializeField] private AudioSource crash;
	[SerializeField] private AudioSource pickup;
	[SerializeField] private AudioSource fire;
	private float delay = 0.8f;
	private bool timeFlag = false;

	private void Start()
    {
		scoreObject.levelIndex = SceneManager.GetActiveScene().buildIndex;
		lastPos = Math.Round(gameObject.transform.position.z);
	}
    // We marked this as "Fixed"Update because we
    // are using it to mess with physics.
    void FixedUpdate()
	{
		if (rb.velocity.z >= speedLimit)
        {
			forwardForceAdded = 0;
        }
        else
        {
			forwardForceAdded = forwardForce;
        }

		if (onFloor)
        {
            if (Input.acceleration.z > .2f)
            {
				jumpInput = 1;
				onFloor = false;
			}
        }
        else
        {
			jumpInput = 0;
        }

		// Add a forward force
		rb.AddForce(Input.acceleration.x * sidewaysForce * Time.deltaTime, jumpInput * jumpForce * Time.deltaTime, forwardForceAdded * Time.deltaTime);

		if (rb.position.y < -1f)
		{
			print("Fell through floor");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		score += Math.Round(gameObject.transform.position.z-lastPos);
		lastPos = Math.Round(gameObject.transform.position.z);
		if (timeFlag)
		{
			delay -= Time.deltaTime;
			if (delay <= 0)
			{
				SceneManager.LoadScene("End_Failed");
			}
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
			onFloor = true;
        }
		if (collision.gameObject.CompareTag("Wall_left"))
		{
			rb.AddForce(1 * sidewaysForce * Time.deltaTime, jumpInput * jumpForce * Time.deltaTime, forwardForceAdded * Time.deltaTime);
		}
		if (collision.gameObject.CompareTag("Wall_right"))
		{
			rb.AddForce(-1 * sidewaysForce * Time.deltaTime, jumpInput * jumpForce * Time.deltaTime, forwardForceAdded * Time.deltaTime);
		}
		if (collision.gameObject.layer == 30)
        {
			timeFlag = true;
			print("Hit an obstacle");
			crash.Play();
			rb.constraints = RigidbodyConstraints.FreezeAll;
			scoreObject.setScoreTemp(scoreObject.getScore() + score);
		}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
			pickup.Play();
			score += 100f;
			ammo++;
        }
		if(other.gameObject.CompareTag("EndTrigger"))
        {
			scoreObject.setScore(scoreObject.getScore() + score);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
    }

	public void Shoot(Vector3 target)
    {
		if (ammo > 0)
		{
			fire.Play();
			Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
			GameObject projectile = Instantiate(bullet, pos, Quaternion.identity);
			projectile.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 10000f));
			ammo--;
		}
	}
	public double getScore()
    {
		return score;
    }

}

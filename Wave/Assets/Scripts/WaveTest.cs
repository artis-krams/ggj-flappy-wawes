﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTest : MonoBehaviour
{

    public GameObject player;
	public AudioClip slowDownSound;
	public AudioClip speedUpSound;
    public float speed;
	public float destroyerSpeed;
	public float speedIncrease;
	public float speedDecrease;
	public float speedIncreasePeriod;
	public float destroyerSpeedIncrease;
    public float score;
    public float waveincrease;
    public float currentwavestrenght;
    public float frequency;  // Speed of sine movement
    public float magnitude;   // Size of sine movement
    public float period;
    public int pickupcount;
	public bool gameOver;
	public int dostroyerStartOffset;
    private int i;
    public GameObject pickup1;
    public GameObject pickup2;
    public GameObject pickup3;
    public GameObject camera;
    public GameObject spawner;
    public GameObject destroyer;
    public GameObject wall1;
    public GameObject wall2;

    private float nextActionTime = 0.0f;
	private float nextSpeedIncreaseTime = 0.0f;
    private int spaceDown = 0;
    private Vector3 axis;
    private Vector3 pos;
    // Use this for initialization
    void Start()
    {

        pos = player.transform.position;
        axis = player.transform.up;
		destroyer.transform.position = new Vector3 (pos.x - dostroyerStartOffset, destroyer.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
		if (!gameOver) {
			camera.transform.position = new Vector3 (player.transform.position.x + 2, 0, -10);

			pos += player.transform.right * Time.deltaTime * speed;
			player.transform.position = pos + axis * Mathf.Sin (Time.time * frequency) * currentwavestrenght;

			spawner.transform.position = new Vector3 (player.transform.position.x + 25, spawner.transform.position.y, 0);

			destroyer.transform.position += destroyer.transform.right * Time.deltaTime * destroyerSpeed;

			wall1.transform.position = new Vector3 (player.transform.position.x, wall1.transform.position.y, 0);
			wall2.transform.position = new Vector3 (player.transform.position.x, wall2.transform.position.y, 0);

			if (Time.time > nextActionTime) {
				nextActionTime += period;

				int sw = Random.Range (0, 3);
				switch (sw) {
				case 0:
					Instantiate (pickup1, new Vector3 (spawner.transform.position.x, Random.Range (8.0f, -8.0f), 0), Quaternion.identity);
					break;
				case 1:
					Instantiate (pickup2, new Vector3 (spawner.transform.position.x, Random.Range (8.0f, -8.0f), 0), Quaternion.identity);
					break;
				case 2:
					Instantiate (pickup3, new Vector3 (spawner.transform.position.x, Random.Range (8.0f, -8.0f), 0), Quaternion.identity);
					break;
				}

			}

			if (Time.time > nextSpeedIncreaseTime) {
				nextSpeedIncreaseTime += speedIncreasePeriod;
				speed += speedIncrease;
				destroyerSpeed += destroyerSpeedIncrease;
				AudioSource.PlayClipAtPoint (speedUpSound, player.transform.position);
			}

			if (Input.GetKey ("space") == true) {
				currentwavestrenght = currentwavestrenght + waveincrease;
			} else {
				if (currentwavestrenght > 0) {
					currentwavestrenght = currentwavestrenght - (3 * waveincrease);
				} else {
					currentwavestrenght = 0;
				}
			}
		}
    }


	public void SlowDown() {
		currentwavestrenght = 0;
		speed -= speedDecrease;
		AudioSource.PlayClipAtPoint (slowDownSound, player.transform.position);
	}
}

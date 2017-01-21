using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveTest : MonoBehaviour
{

    public GameObject player;
	public AudioClip slowDownSound;
	public AudioClip speedUpSound;
    public float speed;
	public float maxSpeed;
	public float minSpeed;
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
	public float tierOne;
	public float tierTwo;
	public float tierThree;
	public float maxDistance;
    public int pickupcount;
	public bool gameOver;
	public int dostroyerStartOffset;
    private int i;
	public GameObject endPanel;
    public GameObject pickup1;
    public GameObject pickup2;
    public GameObject pickup3;
    public GameObject camera;
    public GameObject spawner;
    public GameObject destroyer;
    public GameObject wall1;
    public GameObject wall2;
	public bool allowStart;
	public Text scoreText;
	public Text panelScore;
	public Text hiscore;
	public int maxRange;
    public float minWaveStrength = 0.5f;

    private float nextActionTime = 0.0f;
	private float nextSpeedIncreaseTime = 0.0f;
    private int spaceDown = 0;
    private Vector3 axis;
    private Vector3 pos;

    // Use this for initialization
    void Start()
    {
		hiscore.text = PlayerPrefs.GetFloat("hiscore").ToString();
		//print(hisc);

		score = 0;
		allowStart = false;
        pos = player.transform.position;
        axis = player.transform.up;
		destroyer.transform.position = new Vector3 (pos.x - dostroyerStartOffset, destroyer.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
		if (speed < minSpeed) {
			speed = minSpeed;
		}

		if (speed > maxSpeed) {
			speed = maxSpeed;
		}

		if (destroyerSpeed > maxSpeed) {
			destroyerSpeed = maxSpeed;
		}

		if (speed >= tierOne) {
			maxRange = 3;
		}

		if (speed >= tierTwo) {
			maxRange = 4;
		}

		if (speed >= tierThree) {
			maxRange = 5;
		}

		if (player.transform.position.x - destroyer.transform.position.x <= maxDistance && destroyerSpeed < speed) {
			destroyerSpeed = speed;
		}

		if (Input.GetKey ("space")==true & allowStart==false) {
			//print ("First start");
			FirstStart ();
		}

		if (gameOver & allowStart) {
			if (Input.GetKeyDown("space")==true) {
				//print ("restart");
				RestartGame ();
			}
		}
    }

    void FixedUpdate()
	{  	

		if (!gameOver & allowStart) {
			
			score++;
			scoreText.text = score.ToString();

			camera.transform.position = new Vector3 (player.transform.position.x + 2, 0, -10);

			pos += player.transform.right * Time.deltaTime * speed;
			player.transform.position = pos + axis * Mathf.Sin (Time.time * frequency) * currentwavestrenght;

			spawner.transform.position = new Vector3 (player.transform.position.x + 15, spawner.transform.position.y, 0);

			destroyer.transform.position += destroyer.transform.right * Time.deltaTime * destroyerSpeed;

			wall1.transform.position = new Vector3 (player.transform.position.x, wall1.transform.position.y, 0);
			wall2.transform.position = new Vector3 (player.transform.position.x, wall2.transform.position.y, 0);

			if (Time.time > nextActionTime) {
				nextActionTime += period;

				int sw = Random.Range (0, maxRange);
				switch (sw) {
				case 0:
					Instantiate (pickup3, new Vector3 (spawner.transform.position.x, Random.Range (8.0f, -8.0f), 0), Quaternion.identity);
					break;
				case 1:
					Instantiate (pickup2, new Vector3 (spawner.transform.position.x, Random.Range (8.0f, -8.0f), 0), Quaternion.identity);
					break;
				case 2:
					Instantiate (pickup1, new Vector3 (spawner.transform.position.x, Random.Range (8.0f, -8.0f), 0), Quaternion.identity);
					break;
				case 3:
					Instantiate (pickup1, new Vector3 (spawner.transform.position.x, Random.Range (8.0f, -8.0f), 0), Quaternion.identity);
					break;
				case 4:
					Instantiate (pickup1, new Vector3 (spawner.transform.position.x, Random.Range (8.0f, -8.0f), 0), Quaternion.identity);
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
				destroyerSpeed -= destroyerSpeedIncrease/10;
				currentwavestrenght = currentwavestrenght + 2 * waveincrease;
			} else {
				destroyerSpeed += destroyerSpeedIncrease/100;
				if (currentwavestrenght > minWaveStrength) {
					currentwavestrenght = currentwavestrenght - (4 * waveincrease);
				} else {
					currentwavestrenght = minWaveStrength;
				}
			}
		}
    }


	public void SlowDown() {
		currentwavestrenght = 0;
		speed -= speedDecrease;
		AudioSource.PlayClipAtPoint (slowDownSound, player.transform.position);
	}


	public void FirstStart() {
		nextActionTime = Time.time;
		nextSpeedIncreaseTime = Time.time;
		allowStart = true;
	}



	public void RestartGame() {
		SceneManager.LoadScene (0);

	}

	public void GameOver() {
		gameOver = true;
		allowStart = false;
		endPanel.SetActive (true);
		panelScore.text = score.ToString();

		float hiscore = PlayerPrefs.GetFloat("hiscore");
		if (score>hiscore) {

			PlayerPrefs.SetFloat("hiscore",score);
		}

	} 

	public void QuitGame() {
		Application.Quit ();
	}

}

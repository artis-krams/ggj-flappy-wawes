using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollision : MonoBehaviour
{
    private ParticleSystem particles;
    private bool startedPlay;
    public AudioClip[] sounds;
    public float minRotation = 0.1f;
    public float maxRotation = 1;
	private WaveTest manager;
	private GameObject obj;

    void Start()
    {
		obj = GameObject.FindGameObjectWithTag ("Manager");
		//print (obj);
		manager = obj.GetComponent<WaveTest> ();
		//print (manager);
        particles = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    void FixedUpdate()
    {
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime, Random.Range(minRotation, maxRotation));
        gameObject.transform.Rotate(Vector3.right * Time.deltaTime, Random.Range(minRotation, maxRotation));
        //gameObject.transform.Rotate(Vector3.forward * Time.deltaTime, Random.Range(minRotation, maxRotation));
        if (particles)
        {
            if (!particles.IsAlive() && startedPlay)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "Player")
        {
		//	print (manager.speed);
		//	print (manager.score);

			//manager.score += Mathf.Round(manager.speed*2);


            particles.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
			Destroy (gameObject.transform.GetChild(0).gameObject);
            startedPlay = true;

            AudioSource.PlayClipAtPoint(sounds[Random.Range(0, sounds.Length - 1)], gameObject.transform.position, 0.5f);
        }

		//red ball

		if (col.collider.name == "Player" && this.gameObject.tag=="pickupdecrease") {
			manager.speed = manager.speed - 0.7f;

		}

		if (col.collider.name == "Player" && this.gameObject.tag=="pickupincrease") {
			manager.speed = manager.speed + 1;
			manager.destroyerSpeed -= 0.5f;
			manager.score += Mathf.Round(manager.speed*3);

		}

		if (col.collider.name == "Player" && this.gameObject.tag=="pickup") {
			manager.score += Mathf.Round(manager.speed*2);
			manager.speed = manager.speed + 0.5f;
			manager.destroyerSpeed -= 0.25f;
		}



        if (col.gameObject.name == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}

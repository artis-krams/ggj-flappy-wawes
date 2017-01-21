using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollision : MonoBehaviour
{
    private ParticleSystem particles;

    // Use this for initialization
    void Start()
    {
        particles = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime, 1);
    }
    void OnCollisionEnter(Collision col)
    {
		if (col.collider.name == "Player")
        {
            particles.Play();
//            Destroy(gameObject);
        }

		if (col.gameObject.name == "Destroyer")
		{
			Destroy(gameObject);
		}
    }
}

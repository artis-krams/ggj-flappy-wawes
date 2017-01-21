using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollision : MonoBehaviour
{
    private ParticleSystem particles;
    private bool startedPlay;

    // Use this for initialization
    void Start()
    {
        particles = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime, 1);
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
            particles.Play();
			gameObject.GetComponent<MeshRenderer> ().enabled = false;
            startedPlay = true;
        }

        if (col.gameObject.name == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}

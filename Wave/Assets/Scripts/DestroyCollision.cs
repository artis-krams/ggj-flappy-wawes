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

    void Start()
    {
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
            particles.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            startedPlay = true;

            AudioSource.PlayClipAtPoint(sounds[Random.Range(0, sounds.Length - 1)], gameObject.transform.position);
        }

        if (col.gameObject.name == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedParticles : MonoBehaviour {
    private WaveTest manager;
    ParticleSystem.VelocityOverLifetimeModule velocity;
	void Start () {
        var particles = GetComponent<ParticleSystem>();
        velocity = particles.velocityOverLifetime;

        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<WaveTest>();
    }
	
	// Update is called once per frame
	void Update () {
        velocity.x = -3 - (manager.speed/4);
	}
}

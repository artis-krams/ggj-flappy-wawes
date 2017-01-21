using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioClip[] soundTrack;

	AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!audio.isPlaying) {
			audio.clip = soundTrack[Random.Range(0, soundTrack.Length - 1)];
			audio.Play ();
		}
	}
}

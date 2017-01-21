using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour {
    public float rotationAmmount;
    public Material skyboxMat;

    // Use this for initialization
    void Start () {
        RenderSettings.skybox = skyboxMat;
	}
	
	// Update is called once per frame
	void Update () {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationAmmount);
    }
}

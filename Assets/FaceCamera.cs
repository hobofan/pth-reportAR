using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {
    public Camera targetCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 gazeRotation = Camera.main.transform.forward;
        transform.rotation = Quaternion.LookRotation(gazeRotation);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject platform;
    public Transform generationPoint;

    private float platformLength;

	// Use this for initialization
	void Start () {
        platformLength = platform.GetComponent<BoxCollider>().size.z;
    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position.z < generationPoint.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 
                                             transform.position.z + platformLength);
            Instantiate(platform, transform.position, transform.rotation);
        }
    }
}

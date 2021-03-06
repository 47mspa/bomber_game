﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame 
	// (guaranteed to run after all other updates have been called)
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}

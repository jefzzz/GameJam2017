using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = player.position + offset;
        //transform.position = Vector3.Lerp(transform.position, newPos, 1);
        transform.position = newPos;
	}
}

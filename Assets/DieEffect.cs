using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this, 5f);
	}

    void OnCollisionEnter(Collision collision)
    {

    }

}

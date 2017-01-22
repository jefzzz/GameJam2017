using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlet : MonoBehaviour {
    public GameObject sparkParticle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        GameObject spark = (GameObject)Instantiate(sparkParticle, this.transform.position, Quaternion.identity, this.transform);
        Destroy(spark, 2f);
    }
}

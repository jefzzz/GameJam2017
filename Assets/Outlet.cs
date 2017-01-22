using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlet : MonoBehaviour {
    public GameObject sparkParticle;
    public GameManager manager;
    private Rigidbody rigid;
    private BoxCollider collider;
	// Use this for initialization
	void Start () {
        manager = FindObjectOfType<GameManager>();
        rigid = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.tag != "enemy")
        {
            return;
        }
        GameObject spark = (GameObject)Instantiate(sparkParticle, this.transform.position, Quaternion.identity, this.transform);
        manager.loseLife();
        Destroy(spark, 2f);
        if(manager.lives == 0)
        {
            popOut();
        }
    }

    void popOut()
    {
        rigid.AddForce(this.transform.up * 200);
        rigid.useGravity = true;
        collider.isTrigger = false;
    }
}

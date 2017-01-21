using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    
    public GameObject firepoint;
    public GameObject bulletPrefab;

    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            shoot();
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            openDoor();
        }
	}

    void shoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, firepoint.transform.position, this.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * 1000f);
    }

    void openDoor()
    {
        print("open true");
        anim.SetBool("isOpen", !anim.GetBool("isOpen"));
    }
}

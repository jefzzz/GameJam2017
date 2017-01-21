using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    
    public GameObject firepoint;
    public GameObject bulletPrefab;

    public Animator anim;
    public GameObject door;
    public float targetVel = 1000f;

    private bool isOpen = false;
    private HingeJoint hinge;

    // Use this for initialization
    void Start () {
        hinge = door.GetComponent<HingeJoint>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            shoot();
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            openDoor();
        }
	}

    /* Eat food, whack enemies (forks), get ult to attack multiple enemies at once 
     * 
     * 
     * 
     */
    void shoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, firepoint.transform.position, this.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * 1000f);
    }

    void openDoor()
    {
        JointMotor motor = hinge.motor;
        if (!isOpen)
        {
            motor.targetVelocity = targetVel;
            hinge.motor = motor;
            isOpen = true;
        } else
        {
            motor.targetVelocity = targetVel * -1;
            hinge.motor = motor;
            isOpen = false;
        }
        //anim.SetBool("isOpen", !anim.GetBool("isOpen"));
    }
}

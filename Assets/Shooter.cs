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
    private JointMotor motor;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        motor = door.GetComponent<HingeJoint>().motor;
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
        print(isOpen);
        if (!isOpen)
        {
            motor.targetVelocity = targetVel;
            print(motor.targetVelocity);
            isOpen = true;
        } else
        {
            motor.targetVelocity = targetVel * -1;
            isOpen = false;
        }
        //anim.SetBool("isOpen", !anim.GetBool("isOpen"));
    }
}

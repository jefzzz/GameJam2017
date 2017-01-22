using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    
    public GameObject firepoint;
    public GameObject bulletPrefab;

    public Animator anim;
    public GameObject door;
    public float targetVel = 1000f;

    public bool attackAnimation = false; //accessed by enemies to check when to die (differentiates a door attack vs accidentally bumping into the player's door)

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
            toggleDoor(1f);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            attackAnimation = true;
            attackDoor();
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

    void toggleDoor(float boostFactor)
    {
        JointMotor motor = hinge.motor;
        if (!isOpen)
        {
            motor.targetVelocity = targetVel * boostFactor;
            hinge.motor = motor;
            isOpen = true;
        } else
        {
            motor.targetVelocity = targetVel * -1 * boostFactor;
            hinge.motor = motor;
            isOpen = false;
        }
        //anim.SetBool("isOpen", !anim.GetBool("isOpen"));
    }

    void attackDoor()
    {
        StartCoroutine(spamDoor(4f, .1f));
    }

    IEnumerator spamDoor(float boost, float time)
    {
        toggleDoor(boost);
        yield return new WaitForSeconds(time);
        toggleDoor(boost);
        yield return new WaitForSeconds(time);
        toggleDoor(boost);
        yield return new WaitForSeconds(time);
        toggleDoor(boost);
        yield return new WaitForSeconds(time);
        toggleDoor(boost);
        yield return new WaitForSeconds(time);
        toggleDoor(boost);
        yield return new WaitForSeconds(time);
        attackAnimation = false;

    }
}

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
    public GameObject particleWave;

    public bool isOpen = false;
    public bool isSpecial = false;
    private HingeJoint hinge;
    private stomach stomach;


    // Use this for initialization
    void Start () {
        hinge = door.GetComponent<HingeJoint>();
        stomach = GetComponentInChildren<stomach>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftControl) && !isSpecial)
        {
            shoot();
        }
        if(Input.GetButtonDown("Fire2") && !isSpecial)
        {
            toggleDoor(3f);
        }
        if (Input.GetButtonDown("Fire1") && !isSpecial)
        {
            attackAnimation = true;
            attackDoor();
        }
        if(Input.GetKeyDown(KeyCode.X) && !isSpecial && stomach.count >= 5) {
            stomach.count = 0;
            stomach.points.text = "Power: 0/5";
            useUltimate();
        }
    }

    /* Eat food, whack enemies (forks), get ult to attack multiple enemies at once 
     * 
     * 
     * 
     */

    void useUltimate()
    {
        isSpecial = true;
        toggleDoor(1f);
        StartCoroutine(playSpecialParticle());

    }

    IEnumerator playSpecialParticle()
    {
        GameObject particle = (GameObject)Instantiate(particleWave, this.transform.position, Quaternion.Euler(this.transform.rotation.eulerAngles + new Vector3(0, 180f, 0)), this.transform);
        yield return new WaitForSeconds(1f);
        isSpecial = false;
        toggleDoor(.5f);
        Destroy(particle);
    }

    void shoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, firepoint.transform.position, Quaternion.Euler(-this.transform.rotation.eulerAngles));
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

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
    private GameManager manager;
    private PlayerMovement player;

    // Use this for initialization
    void Start () {
        hinge = door.GetComponent<HingeJoint>();
        stomach = GetComponentInChildren<stomach>();
        manager = FindObjectOfType<GameManager>();
        player = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (manager.isPause)
        {
            return;
        }
        if(Input.GetButtonDown("Fire2") && !isSpecial)
        {
            toggleDoor(.5f);
            player.audio.clip = player.open;
            player.audio.Play();
        }
        if (Input.GetButtonDown("Fire1") && !isSpecial)
        {
            attackAnimation = true;
            attackDoor();
            player.audio.clip = player.attack;
            player.audio.Play();
        }
        if(Input.GetKeyDown(KeyCode.X) && !isSpecial && stomach.count >= 0) {
            stomach.count = 0;
            stomach.points.text = "Power: 0/5";
            useUltimate();
            player.audio.clip = player.special;
            player.audio.Play();
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
        StartCoroutine(playSpecialParticle());

    }

    IEnumerator playSpecialParticle()
    {
        if (!isOpen)
        {
            toggleDoor(1f);
        }
        GameObject particle = (GameObject)Instantiate(particleWave, this.transform.position+ new Vector3(0, 0.2f, 0), Quaternion.Euler(this.transform.rotation.eulerAngles + new Vector3(0, -180f, 0)), this.transform);
        yield return new WaitForSeconds(1f);
        isSpecial = false;
        toggleDoor(.5f);
        Destroy(particle, 3f);
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

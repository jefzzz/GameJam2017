using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    private Rigidbody rigid;
    private Animator anim;
    private Transform player;
    private Shooter shooter;
    private GameManager manager;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>().transform;
        shooter = FindObjectOfType<Shooter>();
        manager = FindObjectOfType<GameManager>();
        anim.SetBool("isWalk", true);

	}
	
	// Update is called once per frame
	void Update () {
        if (manager.isPause)
        {
            return;
        }
        //moveForward();
        if (Input.GetKeyDown(KeyCode.P))
        {
            //anim.SetTrigger("isHop");
        }
        Vector3 diff = this.transform.position - player.position;
        if (diff.magnitude < 20)
        {
            chase();
        }
	}

    void moveForward()
    {
        rigid.AddForce(this.transform.forward * 100f * Time.deltaTime);
    }

    void chase()
    {
        //Vector3 direction = transform.position - player.position;
        Vector3 direction = player.position - transform.position;
        rigid.AddForce(direction.normalized * 100f * Time.deltaTime);
        this.transform.LookAt(player);
        //transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        print(other.gameObject.tag);
        if(other.gameObject.tag == "door" && shooter.attackAnimation)
        {
            Destroy(this.gameObject, 0.5f);
        }
    }

    


}

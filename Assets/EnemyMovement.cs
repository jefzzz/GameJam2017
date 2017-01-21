﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    private Rigidbody rigid;
    private Animator anim;
    private Transform player;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>().transform;
        anim.SetBool("isWalk", true);
	}
	
	// Update is called once per frame
	void Update () {
        //moveForward();
        if(Input.GetKeyDown(KeyCode.P))
        {
            //anim.SetTrigger("isHop");
        }
        Vector3 diff = this.transform.position - player.position;
        if (diff.magnitude < 10)
        {
            runaway();
        } else
        {
            //patrol
        }
	}

    void moveForward()
    {
        rigid.AddForce(this.transform.forward * 100f * Time.deltaTime);
    }

    void runaway()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, -1f * Time.deltaTime);
    }

    void patrol()
    {

    }
}
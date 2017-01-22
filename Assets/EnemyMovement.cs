using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    private Rigidbody rigid;
    private Transform player;
    private Shooter shooter;
    private GameManager manager;

    public float jumpPower = 500;

    public bool shrinking = false;

    public bool isGrounded = true;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerMovement>().transform;
        shooter = FindObjectOfType<Shooter>();
        manager = FindObjectOfType<GameManager>();

	}
	
	// Update is called once per frame
	void Update () {
        if (manager.isPause)
        {
            return;
        }
        if(shrinking)
        {
            shrink();
        }
        //moveForward();
        if (Input.GetKeyDown(KeyCode.P))
        {
            //anim.SetTrigger("isHop");
        }
        Vector3 diff = this.transform.position - player.position;
        if (diff.magnitude < 20 && isGrounded)
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
        isGrounded = false;
        Vector3 direction = player.position - transform.position;
        rigid.AddForce(direction.normalized * 1000f * Time.deltaTime);
        rigid.AddForce(Vector3.up * jumpPower);
        //this.transform.LookAt(player);
        //transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        print(other.gameObject.tag);
        if(other.gameObject.tag == "door" && shooter.attackAnimation)
        {
            Vector3 direction = player.position - transform.position;
            rigid.AddForce(-direction * 100f);
            rigid.AddForce(Vector3.up * 100f);
            shrinking = true;
        }
        if(other.gameObject.tag == "kitchen")
        {
            isGrounded = true;
        }
    }

    void shrink ()
    {
        if (this.transform.localScale.x < 0.2f)
        {
            Destroy(this.gameObject);
        }
        this.transform.localScale -= new Vector3(1f, 1f, 1f) * Time.deltaTime; 
    }

    


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    private Rigidbody rigid;
    private Transform player;
    private GameManager manager;
    public bool isGrounded = true;
    public float jumpPower = 50f;
    public float runPower = 100f;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerMovement>().transform;
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.isPause)
        {
            return;
        }
        //moveForward();
        if (Input.GetKeyDown(KeyCode.P))
        {
            //anim.SetTrigger("isHop");
        }
        Vector3 diff = this.transform.position - player.position;
        if (diff.magnitude < 6)
        {
            runaway();
        }
        else
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
        isGrounded = false;
        Vector3 direction = player.position - transform.position;
        rigid.AddForce(-direction.normalized * runPower * Time.deltaTime);
        rigid.AddForce(Vector3.up * jumpPower * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, player.position, -0.1f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "kitchen")
        {
            isGrounded = true;
        }
    }
}

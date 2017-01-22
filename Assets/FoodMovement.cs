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

    public float timer = 0;
    public float timerMax = 2f;

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
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        //moveForward();
        if (Input.GetKeyDown(KeyCode.P))
        {
            //anim.SetTrigger("isHop");
        }
        Vector3 diff = this.transform.position - player.position;
        if (diff.magnitude < 6 && isGrounded && timer <= 0)
        {
            runaway();
        }
        else
        {
            //patrol
        }
    }

    void runaway()
    {
        timer = timerMax;
        isGrounded = false;
        Vector3 direction = player.position - transform.position;
        rigid.AddForce(-direction.normalized * runPower, ForceMode.VelocityChange);
        rigid.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
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

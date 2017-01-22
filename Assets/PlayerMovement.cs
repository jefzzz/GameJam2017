using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rigid;
    public float forwardScale = 1000f;
    public int rotateScale = 5000;
    public float jumpScale = 50f;
    public GameObject test;

    public GameObject help;
    public GameObject power;

    public GameManager  manager;

    private float jumpCount = 0f;
    private float jumpReset = 1.25f;

    public bool isGrounded = true;

	void Start () {
        manager = FindObjectOfType<GameManager>();
	}
	
	void FixedUpdate () {
        if (manager.isPause)
        {
            return;
        }
        if (jumpCount > 0)
        {
            jumpCount -= Time.deltaTime;
        }
        /*
        if (Input.GetButton("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                Vector3 target = new Vector3(hit.point.x, 0f, hit.point.z);
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(hit.point.x, 0f, hit.point.z), 2f * Time.deltaTime);
                transform.LookAt(-target * Time.deltaTime * 2f);

            }
        }*/
        controls();
	}

    void controls()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(this.transform.forward * forwardScale * Time.deltaTime * -1, ForceMode.VelocityChange);
        }
        if(Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(this.transform.forward * forwardScale * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddRelativeTorque(this.transform.up * rotateScale * Time.deltaTime * -1, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddRelativeTorque(this.transform.up * rotateScale * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount <= 0)
        {
            jumpCount = jumpReset;
            rigid.AddForce(this.transform.up * jumpScale, ForceMode.VelocityChange);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            toggleHelp();
        }
    }

    void toggleHelp()
    {
        help.SetActive(!help.activeSelf);
        power.SetActive(!help.activeSelf);
    }

}

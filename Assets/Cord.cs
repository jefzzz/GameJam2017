using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class Cord : MonoBehaviour {
    public LineRenderer line;
    public Rigidbody rigid;
    public Transform target;
    public Transform start;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        line.SetPosition(0, start.transform.position);
        line.SetPosition(1, target.transform.position);
    }
}

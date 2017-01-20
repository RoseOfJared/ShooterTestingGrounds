using UnityEngine;
using System.Collections;

public class BasicJump : MonoBehaviour
{
	public bool isJumping = true;
	public bool isJumping2 = true;
	public float jumpPower = 1;
	
	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
		if(Input.GetButtonDown("Jump"))
		{
			
			if(isJumping == false)
			{
				rigidbody3D.AddForce(transform.up*jumpPower);
				grounded = true;
			}
			else if(!isJumping2)
			{
				//addmoreforce & isJumping2 = true
			}
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Ground")
		{
			isJumping = false;
			isJumping2 = false;
		}
	}
	
	
}
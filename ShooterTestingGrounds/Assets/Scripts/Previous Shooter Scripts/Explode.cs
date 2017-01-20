using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour
{
	public GameObject explosionParticles;
	public float blastRadius = 1;
	public int damage = 1;
	
	private bool explode;
	
	void OnCollisionEnter()
	{
		explosionParticles.SetActive(true);
		explosionParticles.transform.SetParent(null);
		explode = true;
	}
	
	
	void FixedUpdate()
	{
		if(explode)
		{
			Colliders[] hitColliders = Physics.OverlapSphere(transform.position, blastRadius);
			
			for(int i = 0; i < hitColliders.Length; i++)
			{
				if(hitColliders[i].GetComponent<IDamageable>() != null)
				{
					hitColliders[i].GetComponent<IDamageable>().Damage(damage, hitColliders[i].transform.position);
					
				}
				
				if(hitColliders[i].GetComponent<Rigidbody>() != null)
				{
					hitColliders[i].GetComponent<Rigidbody>()AddExplosionForce(6000, transform.position, blastRadius);
				}
			}
			this.gameObject.SetActive(false);
		}
	}
}
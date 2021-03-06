using UnityEngine;
using System.Collections;

public class RaycastShootScript : MonoBehaviour
{
	public float fireRate = .25f;
	public float range = 50f;
	public ParticleSystem smokeParticles;
	public GameObject hitParticles;
	public GameObject shootFlare;
	public int damage = 1;
	public Transform gunEnd;
	
	private Camera fpsCam;
	private LineRenderer lineRenderer;
	private WaitForSeconds shotLength = new WaitForSeconds(0.07f);
	private AudioSource source;
	private float nextFireTime;
	
	
	void Awake()
	{
		lineRenderer = GetComponent<LineRenderer>();
		source = GetComponent<AudioSource>();
		fpsCam = GetComponentInParent<Camera>();
	}
	
	void Update()
	{
		RaycastHit hit;
		Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
		
		if(Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
		{
			nextFireTime = Time.time + fireRate;
			
			if(Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, range))
			{
				IDamageable dmgScript = hit.collider.gameObject.GetComponent<EnemyHealth>();
				if(dmgScript != null)
				{
					dmgScript.Damage(damage, hit.point);
				}
				
				if(hit.rigidbody != null)
				{
					hit.rigidbody.AddForce(-hit.normal * 100f);
				}
				
				lineRenderer.SetPosition(0, gunEnd.position);
				lineRenderer.SetPosition(1, hit.point);
				Instantiate(hitParticles, hitParticles, Quaternion.identity);
			}
			StartCoroutine(ShotEffect_cr());
		}
		
	}
	
	
	private IEnumerator ShotEffect_cr()
	{
		lineRenderer.enabled = true;
		source.Play();
		smokeParticles.Play();
		shootFlare.SetActive();
		
		yield return shotLength;
		
		lineRenderer.enabled = false;
		shootFlare.SetActive(false);
	}
}





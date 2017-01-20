using UnityEngine;
using System.Collections;

public class BoxDamage : MonoBehaviour, IDamageable {
	
	private MeshRenderer myRenderer;
	
	void Awake()
	{
		
	}
	
	public void Damage(int damage, Vector3 hitPoint)
	{
		myRenderer.material.color = Color.red;
	}
	
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public Text GUI_Text;
	private uint PrivHealth;

	// Use this for initialization
	void Start () 
	{
		PrivHealth = 100;
		GUI_Text.text = PrivHealth.ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
		GUI_Text.text = PrivHealth.ToString();
		Debug.Log (PrivHealth.ToString());
		if(Input.GetKeyDown(KeyCode.T) == true)
		{
			PrivHealth -= 10;
			if(PrivHealth == 0)
			{
				PrivHealth = 0;
			}
		}

		if(Input.GetKeyDown(KeyCode.G) == true && PrivHealth < 100)
		{
			PrivHealth += 3;
		}


	}
}

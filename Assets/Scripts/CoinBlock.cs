using UnityEngine;
using System.Collections;

public class CoinBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D _Other)
	{
		GameObject OtherGO = _Other.gameObject;

		if (OtherGO.CompareTag ("Player")) 
		{
			RoboAbbilities Abbilities = OtherGO.GetComponent<RoboAbbilities> ();

			if (Abbilities != null) {
				Abbilities.m_Coins += 1;

				Destroy (gameObject);
			}
		}
	}
}

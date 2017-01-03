using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

	public RoboAbbilities m_Abbilities;

	public Text m_Coins;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		m_Coins.text = "Coins: " + m_Abbilities.m_Coins;
	}
}

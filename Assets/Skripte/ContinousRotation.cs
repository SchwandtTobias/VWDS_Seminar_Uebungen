using UnityEngine;
using System.Collections;

public class ContinousRotation : MonoBehaviour 
{

	public float m_AngleInDegreeX = 0.0f;
	public float m_AngleInDegreeY = 0.0f;
	public float m_AngleInDegreeZ = 0.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.rotation = Quaternion.Euler (
			transform.rotation.eulerAngles.x + Mathf.Deg2Rad * m_AngleInDegreeX * Time.deltaTime,
			transform.rotation.eulerAngles.y + Mathf.Deg2Rad * m_AngleInDegreeY * Time.deltaTime,
			transform.rotation.eulerAngles.z + Mathf.Deg2Rad * m_AngleInDegreeZ * Time.deltaTime);
	}
}

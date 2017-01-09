using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowEntity : MonoBehaviour {

    public Transform m_ObjectToFollow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (m_ObjectToFollow != null)
		{
            transform.position = new Vector3(m_ObjectToFollow.position.x, m_ObjectToFollow.position.y, transform.position.z);
		}
	}
}

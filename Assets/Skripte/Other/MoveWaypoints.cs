using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveWaypoints : MonoBehaviour 
{
	public float m_Speed = 5.0f;

	public Transform[] m_Waypoints;

	private int m_CurrentWaypointAhead;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (m_Waypoints.Length > 0) 
		{
			Vector3 NextWaypoint = m_Waypoints [m_CurrentWaypointAhead].position;

			transform.position += Vector3.Normalize(NextWaypoint - transform.position) * m_Speed * Time.deltaTime;

			if (Vector3.Distance (NextWaypoint, transform.position) < 0.1f) 
			{
				m_CurrentWaypointAhead = ++m_CurrentWaypointAhead % m_Waypoints.Length;
			}
		}
	}
}

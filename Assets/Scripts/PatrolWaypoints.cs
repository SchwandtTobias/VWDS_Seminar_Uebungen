using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class PatrolWaypoints : MonoBehaviour
{
    public List<GameObject> m_Waypoints;

    private int m_CurrentWaypointAhead = 0;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        if (m_Waypoints.Count > 0)
        {
            GameObject NextWaypoint = m_Waypoints[m_CurrentWaypointAhead];

            GetComponent<EnemyController>().m_Target = NextWaypoint;

            if (Vector3.Distance(NextWaypoint.transform.position, transform.position) < 0.01f)
            {
                m_CurrentWaypointAhead = ++m_CurrentWaypointAhead % m_Waypoints.Count;
            }
        }
	}
}

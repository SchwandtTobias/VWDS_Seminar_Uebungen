using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyPatrolState : IEnemyState
{
    private readonly EnemyController m_EnemyController;

    private int m_CurrentWaypointAhead = 0;

    public EnemyPatrolState(EnemyController statePatternEnemy)
    {
        m_EnemyController = statePatternEnemy;
    }

    public void UpdateState()
    {
        Patrol();
    }

    public void OnTriggerEnter2D(Collider2D _Other)
    {
        if (_Other.gameObject.CompareTag("Player"))
        {
            m_EnemyController.m_Target = _Other.gameObject;

            ToAlertState();
        }
    }

    public void OnTriggerExit2D(Collider2D _Other)
    {

    }

    public void ToPatrolState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToAlertState()
    {
        m_EnemyController.m_CurrentState = EnemyController.EStates.Alert;
    }

    public void ToChaseState()
    {
        m_EnemyController.m_CurrentState = EnemyController.EStates.Chase;
    }

    void Patrol()
    {
        if (m_EnemyController.m_Waypoints.Count > 0)
        {
            GameObject NextWaypoint = m_EnemyController.m_Waypoints[m_CurrentWaypointAhead];

            Vector2 Direction = Vector3.Normalize(NextWaypoint.transform.position - m_EnemyController.transform.position);

            m_EnemyController.m_Rigidbody.MovePosition(new Vector2(m_EnemyController.transform.position.x, m_EnemyController.transform.position.y) + Direction * m_EnemyController.m_Speed * Time.deltaTime);

            if (Vector3.Distance(NextWaypoint.transform.position, m_EnemyController.transform.position) < 0.1f)
            {
                m_CurrentWaypointAhead = ++m_CurrentWaypointAhead % m_EnemyController.m_Waypoints.Count;
            }
        }
    }
}

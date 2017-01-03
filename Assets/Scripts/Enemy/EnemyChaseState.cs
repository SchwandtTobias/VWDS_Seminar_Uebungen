using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : IEnemyState
{
    private readonly EnemyController m_EnemyController;

    public EnemyChaseState(EnemyController statePatternEnemy)
    {
        m_EnemyController = statePatternEnemy;
    }

    public void UpdateState()
    {
        Chase();
    }

    public void OnTriggerEnter2D(Collider2D _Other)
    {
    }

    public void OnTriggerExit2D(Collider2D _Other)
    {
        if (_Other.gameObject.CompareTag("Player"))
        {
            ToPatrolState();
        }
    }

    public void ToPatrolState()
    {
        m_EnemyController.m_CurrentState = EnemyController.EStates.Patrol;
    }

    public void ToAlertState()
    {
        m_EnemyController.m_CurrentState = EnemyController.EStates.Alert;
    }

    public void ToChaseState()
    {
        Debug.Log("Can't transition to same state");
    }

    void Chase()
    {
        if (m_EnemyController.m_Target != null)
        {
            Vector2 Direction = Vector3.Normalize(m_EnemyController.m_Target.transform.position - m_EnemyController.transform.position);

            m_EnemyController.m_Rigidbody.MovePosition(new Vector2(m_EnemyController.transform.position.x, m_EnemyController.transform.position.y) + Direction * m_EnemyController.m_Speed * Time.deltaTime);
        }
    }
}

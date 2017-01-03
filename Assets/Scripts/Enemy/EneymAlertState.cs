using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlertState : IEnemyState
{
    private readonly EnemyController m_EnemyController;
    private float m_SearchTimer;

    public EnemyAlertState(EnemyController statePatternEnemy)
    {
        m_EnemyController = statePatternEnemy;
    }

    public void UpdateState()
    {
        Search();
    }

    public void OnTriggerEnter2D(Collider2D _Other)
    {
    }

    public void OnTriggerExit2D(Collider2D _Other)
    {
        if (m_EnemyController.m_Target == _Other.gameObject)
        {
            m_EnemyController.m_Target = null;

            ToPatrolState();
        }
    }

    public void ToPatrolState()
    {
        m_EnemyController.m_CurrentState = EnemyController.EStates.Patrol;

        m_SearchTimer = 0.0f;
    }

    public void ToAlertState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToChaseState()
    {
        m_EnemyController.m_CurrentState = EnemyController.EStates.Chase;

        m_SearchTimer = 0.0f;
    }

    private void Search()
    {
        m_SearchTimer += Time.deltaTime;

        if (m_SearchTimer >= 2.0f && m_EnemyController.m_Target != null)
        {
            ToChaseState();
        }
    }
}

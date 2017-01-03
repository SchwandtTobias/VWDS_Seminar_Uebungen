using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{ 
    public float m_Speed = 4.0f;

    public List<GameObject> m_Waypoints;

    public enum EStates
    {
        Patrol = 0,
        Alert  = 1,
        Chase  = 2,
    }

    public EStates m_CurrentState;

    [HideInInspector]
    private IEnemyState[] m_States;

    [HideInInspector]
    public GameObject m_Target = null;

    [HideInInspector]
    public Rigidbody2D m_Rigidbody;

    // Use this for initialization
    void Start()
    {
        m_States = new IEnemyState[]
        {
            new EnemyPatrolState(this),
            new EnemyAlertState(this),
            new EnemyChaseState(this)
        };

        m_CurrentState = EStates.Patrol;

        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        m_States[(int)m_CurrentState].UpdateState();
    }

    private void OnTriggerEnter2D(Collider2D _Other)
    {
        m_States[(int)m_CurrentState].OnTriggerEnter2D(_Other);
    }

    private void OnTriggerExit2D(Collider2D _Other)
    {
        m_States[(int)m_CurrentState].OnTriggerExit2D(_Other);
    }
}

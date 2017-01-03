using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAttributes))]
[RequireComponent(typeof(PatrolWaypoints))]
[RequireComponent(typeof(CircleCollider2D))]
public class EnemyController : MonoBehaviour {

    public GameObject m_Target = null;

    private PatrolWaypoints m_PatrolScript;

    private Vector3 m_ContinousPosition;

    // Use this for initialization
    void Start()
    {
        m_PatrolScript = GetComponent<PatrolWaypoints>();

        m_ContinousPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update()
    {
        if (m_Target != null)
        {
            m_ContinousPosition += Vector3.Normalize(m_Target.transform.position - m_ContinousPosition) * GetComponent<EnemyAttributes>().m_Speed * Time.deltaTime;

            transform.position = new Vector3(Mathf.Round(m_ContinousPosition.x), Mathf.Round(m_ContinousPosition.y), Mathf.Round(m_ContinousPosition.z));
        }
    }

    // Trigger enter is called if object collides with this entity
    void OnTriggerEnter2D(Collider2D _Other)
    {
        if (_Other.CompareTag("Player"))
        {
            m_PatrolScript.enabled = false;

            m_Target = _Other.gameObject;
        }
    }

    // Trigger enter is called if object collides with this entity
    void OnTriggerStay2D(Collider2D _Other)
    {

    }

    // Trigger enter is called if object collides with this entity
    void OnTriggerExit2D(Collider2D _Other)
    {
        if (_Other.CompareTag("Player"))
        {
            m_Target = null;

            m_PatrolScript.enabled = true;
        }
    }
}

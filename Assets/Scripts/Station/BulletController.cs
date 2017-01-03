using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float m_Damage = 0.0f;

    private bool m_IsFired = false;

    private Vector3 m_Target;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_IsFired)
        {
            transform.position += (m_Target - transform.position).normalized * 0.1f;

            if (Vector3.Distance(m_Target, transform.position) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
	}

    public void Shoot(GameObject _Target)
    {
        m_Target = _Target.transform.position;

        m_IsFired = true;
    }

    // Trigger enter is called if object collides with this entity
    void OnTriggerEnter2D(Collider2D _Other)
    {
        if (_Other.CompareTag("Player"))
        {
            PlayerController Attributes = _Other.GetComponent<PlayerController>();

            Attributes.m_Health -= GetComponent<BulletController>().m_Damage;

            Destroy(gameObject);
        }
    }
}

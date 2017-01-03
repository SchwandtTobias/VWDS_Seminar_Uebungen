using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour {

    public GameObject m_BulletPrefab;

    public float m_FireRate = 1.0f;

    public float m_Timer = 0.0f;

    private GameObject m_Target = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Target != null)
        {
            // Rotation
            Vector3 Direction = m_Target.transform.position - transform.position;

            float Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);

            // Shooting
            m_Timer += Time.deltaTime;

            if (m_Timer >= m_FireRate)
            {
                BulletController Bullet = Instantiate(m_BulletPrefab, transform.position, transform.rotation).GetComponent<BulletController>();

                Bullet.Shoot(m_Target);

                m_Timer = 0.0f;
            }
        }        
    }

    // Trigger enter is called if object collides with this entity
    void OnTriggerEnter2D(Collider2D _Other)
    {
        if (_Other.CompareTag("Player") == false) return;

        m_Target = _Other.gameObject;
    }

    // Trigger enter is called if object collides with this entity
    void OnTriggerStay2D(Collider2D _Other)
    {
        
    }

    // Trigger enter is called if object collides with this entity
    void OnTriggerExit2D(Collider2D _Other)
    {
        m_Timer = 0.0f;

        m_Target = null;
    }
}

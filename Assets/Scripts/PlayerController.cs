using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float m_Speed = 4.0f; 
    public float m_Health = 100.0f;

    private Rigidbody2D m_Rigidbody;

	// Use this for initialization
	void Start ()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_Rigidbody.velocity = Vector2.zero;

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical   = Input.GetAxis("Vertical");

        Vector2 Direction = new Vector3(Horizontal, Vertical);

        m_Rigidbody.MovePosition(new Vector2(transform.position.x, transform.position.y) + Direction * Time.deltaTime * m_Speed);
    }
}

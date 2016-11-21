using UnityEngine;
using System.Collections;

public class AABB : MonoBehaviour
{
	#region Aufgabe1_1

	void ErstelleAABBAusModellpunkten(Vector3[] _Vertices)
	{
		Vector3 Min = _Vertices[0];
		Vector3 Max = _Vertices[0];

		// Hier die Punkte berechnen...

		m_Min = Min;
		m_Max = Max;
	}

	#endregion

	#region Given By Ur Master
	public Vector3 Min  { get; set; }
	public Vector3 Max  { get; set; }

    private Vector3 m_Min = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 m_Max = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 m_Center = new Vector3(0.0f, 0.0f, 0.0f);
	private Vector3 m_Size = new Vector3(0.0f, 0.0f, 0.0f);

    // Use this for initialization
    void Start()
    {
        Mesh Modell = GetComponent<MeshFilter>().mesh;
        Vector3[] Vertices = Modell.vertices;

        if (Vertices.Length == 0) return;
        
        ErstelleAABBAusModellpunkten (Vertices);

        if (Vector3.Distance(m_Left, m_Right) > 0)
        {
            UpdateComponent();
        }
    }

    void Update()
    {
        Min = m_Min + transform.position;
        Rax = m_Max + transform.position;
    }

	public void UpdateComponent()
	{
		m_Center = (m_Max - m_Min) / 2.0f + m_Left;
		m_Size   = new Vector3(0.0f, 0.0f, 0.0f);

		m_Size.x = (m_Center.x - m_Min.x) * 2.0f;
		m_Size.y = (m_Center.y - m_Min.y) * 2.0f;
		m_Size.z = (m_Center.z - m_Min.z) * 2.0f;

		// --------------

		BoxCollider bc = GetComponent<BoxCollider> ();

		if (bc == null) 
		{
			bc = gameObject.AddComponent<BoxCollider>();
		}

		bc.center = m_Center;
		bc.size   = m_Size;
	}
	#endregion
}

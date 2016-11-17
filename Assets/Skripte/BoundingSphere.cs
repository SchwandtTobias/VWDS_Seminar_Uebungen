using UnityEngine;
using System.Collections;

public class BoundingSphere : MonoBehaviour
{
	#region Aufgabe1_2

	void ErstelleBoundingSphereAusModellpunkten(Vector3[] _Vertices)
	{
		// -----------------------------------------------------------------------------
		// Mittelpunkt
		// -----------------------------------------------------------------------------
		Vector3 Mittelpunkt = new Vector3(0, 0, 0);

		for (int IndexOfVertex = 0; IndexOfVertex < _Vertices.Length; ++IndexOfVertex)
		{
			Mittelpunkt += _Vertices[IndexOfVertex];
		}

		Mittelpunkt = Mittelpunkt / _Vertices.Length;

		// -----------------------------------------------------------------------------
		// Radius
		// -----------------------------------------------------------------------------
		float Abstand = 0.0f;

		for (int IndexOfVertex = 0; IndexOfVertex < _Vertices.Length; ++IndexOfVertex)
		{
			float Distance = Vector3.Distance(Mittelpunkt, _Vertices[IndexOfVertex]);

			if (Distance > Abstand)
			{
				Abstand = Distance;
			}
		}

        m_Center = Mittelpunkt;
		m_Radius = Abstand;
	}

	#endregion

	#region Given By Ur Master

	public Vector3 Center { get; set; }
	public float Radius { get; set; }

    Vector3 m_Center = new Vector3(0.0f, 0.0f, 0.0f);
    float m_Radius = 0.0f;

    // Use this for initialization
    void Start()
	{
		Mesh Modell = GetComponent<MeshFilter>().mesh;
		Vector3[] Vertices = Modell.vertices;

		if (Vertices.Length == 0) return;

		ErstelleBoundingSphereAusModellpunkten (Vertices);

        if (m_Radius > 0)
        {
            UpdateComponent();
        }
	}

    void Update()
    {
        Center = m_Center + transform.position;
        Radius = m_Radius;
    }

	public void UpdateComponent()
	{
		SphereCollider sc = GetComponent<SphereCollider> ();

		if (sc == null) 
		{
			sc = gameObject.AddComponent<SphereCollider>();
		}

		sc.center = m_Center;
		sc.radius = m_Radius;
	}
	#endregion
}

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
			
		Center = Mittelpunkt;
		Radius = Abstand;
	}

	#endregion

	#region Given By Ur Master

	public Vector3 Center { get; set; }
	public float Radius { get; set; }

	// Use this for initialization
	void Start()
	{
		Mesh Modell = GetComponent<MeshFilter>().mesh;
		Vector3[] Vertices = Modell.vertices;

		if (Vertices.Length == 0) return;

		ErstelleBoundingSphereAusModellpunkten (Vertices);

		UpdateComponent();
	}

	public void UpdateComponent()
	{
		SphereCollider sc = GetComponent<SphereCollider> ();

		if (sc == null) 
		{
			sc = gameObject.AddComponent<SphereCollider>();
		}

		sc.center = Center;
		sc.radius = Radius;

		// --------------

		Center = Center + transform.position;
	}
	#endregion
}

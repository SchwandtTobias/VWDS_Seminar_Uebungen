using UnityEngine;
using System.Collections;

public class AABB : MonoBehaviour
{
	#region Aufgabe1_1

	void ErstelleAABBAusModellpunkten(Vector3[] _Vertices)
	{
		Vector3 LinksUnten = _Vertices[0];
		Vector3 RechtsOben = _Vertices[0];

		for (int IndexOfVertex = 0; IndexOfVertex < _Vertices.Length; ++IndexOfVertex)
		{
			LinksUnten.x = Mathf.Min(_Vertices[IndexOfVertex].x, LinksUnten.x);
			LinksUnten.y = Mathf.Min(_Vertices[IndexOfVertex].y, LinksUnten.y);
			LinksUnten.z = Mathf.Min(_Vertices[IndexOfVertex].z, LinksUnten.z);

			RechtsOben.x = Mathf.Max(_Vertices[IndexOfVertex].x, RechtsOben.x);
			RechtsOben.y = Mathf.Max(_Vertices[IndexOfVertex].y, RechtsOben.y);
			RechtsOben.z = Mathf.Max(_Vertices[IndexOfVertex].z, RechtsOben.z);
		}
			
		Left  = LinksUnten;
		Right = RechtsOben;
	}

	#endregion

	#region Given By Ur Master
	public Vector3 Left  { get; set; }
	public Vector3 Right { get; set; }

	private Vector3 m_Center;
	private Vector3 m_Size;

    // Use this for initialization
    void Start()
    {
        Mesh Modell = GetComponent<MeshFilter>().mesh;
        Vector3[] Vertices = Modell.vertices;

        if (Vertices.Length == 0) return;

		ErstelleAABBAusModellpunkten (Vertices);

		UpdateComponent();
    }

	public void UpdateComponent()
	{
		m_Center = (Right - Left) / 2.0f + Left;
		m_Size   = new Vector3(0.0f, 0.0f, 0.0f);

		m_Size.x = (m_Center.x - Left.x) * 2.0f;
		m_Size.y = (m_Center.y - Left.y) * 2.0f;
		m_Size.z = (m_Center.z - Left.z) * 2.0f;

		Left   = Left  + transform.position;
		Right  = Right + transform.position;

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

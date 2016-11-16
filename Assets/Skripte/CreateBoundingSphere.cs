using UnityEngine;
using System.Collections;

public class CreateBoundingSphere : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        Mesh Modell = GetComponent<MeshFilter>().mesh;
        Vector3[] Vertices = Modell.vertices;

        // -----------------------------------------------------------------------------
        // Mittelpunkt
        // -----------------------------------------------------------------------------
        Vector3 Mittelpunkt = new Vector3(0, 0, 0);

        for (int IndexOfVertex = 0; IndexOfVertex < Vertices.Length; ++IndexOfVertex)
        {
            Mittelpunkt += Vertices[IndexOfVertex];
        }

        Mittelpunkt = Mittelpunkt / Vertices.Length;

        // -----------------------------------------------------------------------------
        // Radius
        // -----------------------------------------------------------------------------
        float Radius = 0.0f;

        for (int IndexOfVertex = 0; IndexOfVertex < Vertices.Length; ++IndexOfVertex)
        {
            float Distance = Vector3.Distance(Mittelpunkt, Vertices[IndexOfVertex]);

            if (Distance > Radius)
            {
                Radius = Distance;
            }
        }

        Debug.Log(Mittelpunkt);
        Debug.Log(Radius);

        AddBoundingSphereToObject(Mittelpunkt, Radius);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void AddBoundingSphereToObject(Vector3 _Center, float _Radius)
    {
        SphereCollider sc = gameObject.AddComponent<SphereCollider>();

        sc.center = _Center;
        sc.radius = _Radius;
    }
}

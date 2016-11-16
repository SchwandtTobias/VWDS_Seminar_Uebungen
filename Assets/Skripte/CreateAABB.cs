using UnityEngine;
using System.Collections;

public class CreateAABB : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Mesh Modell = GetComponent<MeshFilter>().mesh;
        Vector3[] Vertices = Modell.vertices;

        if (Vertices.Length == 0) return;

        // -----------------------------------------------------------------------------
        // Punkte
        // -----------------------------------------------------------------------------
        Vector3 LinksUnten = Vertices[0];
        Vector3 RechtsOben = Vertices[0];

        for (int IndexOfVertex = 0; IndexOfVertex < Vertices.Length; ++IndexOfVertex)
        {
            LinksUnten.x = Mathf.Min(Vertices[IndexOfVertex].x, LinksUnten.x);
            LinksUnten.y = Mathf.Min(Vertices[IndexOfVertex].y, LinksUnten.y);
            LinksUnten.z = Mathf.Min(Vertices[IndexOfVertex].z, LinksUnten.z);

            RechtsOben.x = Mathf.Max(Vertices[IndexOfVertex].x, RechtsOben.x);
            RechtsOben.y = Mathf.Max(Vertices[IndexOfVertex].y, RechtsOben.y);
            RechtsOben.z = Mathf.Max(Vertices[IndexOfVertex].z, RechtsOben.z);
        }

        AddAABBToObject(LinksUnten, RechtsOben);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AddAABBToObject(Vector3 _Left, Vector3 _Right)
    {
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();

        Vector3 Center = (_Right - _Left) / 2 + _Left;
        Vector3 Size   = new Vector3(5, 5, 5);

        bc.center = Center;
        bc.size   = Size;
    }
}

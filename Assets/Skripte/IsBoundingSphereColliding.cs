using UnityEngine;
using System.Collections;

public class IsBoundingSphereColliding : MonoBehaviour 
{
    #region Aufgabe2_1
    public GameObject m_Other;

    public ParticleSystem m_ParticleSystem;

    bool PruefeKollisionMitBoundingSphere(BoundingSphere _Sphere1, BoundingSphere _Sphere2)
	{
		// Hier die Kollision berechnen...

		return false;
	}

    void OnCollision()
    {
        Destroy(m_Other);

        m_ParticleSystem.Play();
    }
	#endregion

	#region Given By Ur Master
	private BoundingSphere m_MySphereCollider;

	// Use this for initialization
	void Start () 
	{
		m_MySphereCollider = gameObject.GetComponent<BoundingSphere> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool IsColliding = false;

        if (m_Other == null)
        {
            return;
        }

		BoundingSphere OtherSphere = m_Other.GetComponent<BoundingSphere> ();
		AABB           OtherBox    = m_Other.GetComponent<AABB> ();

		if (OtherSphere != null) 
		{
			IsColliding = PruefeKollisionMitBoundingSphere (m_MySphereCollider, OtherSphere);
		}

        if (IsColliding)
        {
            OnCollision();
        }
	}
	#endregion
}

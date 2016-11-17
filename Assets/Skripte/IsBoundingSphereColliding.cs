using UnityEngine;
using System.Collections;

public class IsBoundingSphereColliding : MonoBehaviour 
{
	#region Aufgabe2_1
	bool PruefeKollisionMitBoundingSphere(BoundingSphere _Sphere1, BoundingSphere _Sphere2)
	{
		float AbstandMittelpunkte = Vector3.Distance (_Sphere1.Center, _Sphere2.Center);

		return AbstandMittelpunkte < (_Sphere1.Radius + _Sphere2.Radius);
	}
	#endregion

	#region Given By Ur Master
	public GameObject m_Other;

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

		BoundingSphere OtherSphere = m_Other.GetComponent<BoundingSphere> ();
		AABB           OtherBox    = m_Other.GetComponent<AABB> ();

		if (OtherSphere != null) 
		{
			IsColliding = PruefeKollisionMitBoundingSphere (m_MySphereCollider, OtherSphere);
		}
	}
	#endregion
}

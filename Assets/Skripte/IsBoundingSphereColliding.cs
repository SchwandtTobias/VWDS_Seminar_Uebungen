using UnityEngine;
using System.Collections;

public class IsBoundingSphereColliding : MonoBehaviour 
{
	#region Aufgabe2_1
	bool PruefeKollisionMitBoundingSphere(SphereCollider _Sphere1, SphereCollider _Sphere2)
	{
		return false;
	}

	bool PruefeKollisionMitAABB(SphereCollider _Sphere, BoxCollider _Box)
	{
		return false;
	}
	#endregion

	public GameObject m_Other;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool IsColliding = false;

		SphereCollider Sphere = m_Other.GetComponents<SphereCollider> () [0];

		SphereCollider OtherSphere = m_Other.GetComponents<SphereCollider> () [0];
		BoxCollider    OtherBox    = m_Other.GetComponents<BoxCollider> () [0];

		if (OtherSphere != null) {
			IsColliding = PruefeKollisionMitBoundingSphere (Sphere, OtherSphere);
		}
		else if (OtherBox != null) {
			IsColliding = PruefeKollisionMitAABB (Sphere, OtherBox);
		}
	}
}

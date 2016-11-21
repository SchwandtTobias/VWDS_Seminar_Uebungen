using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IsAABBColliding : MonoBehaviour
{
    #region Aufgabe2_2
    public Text m_Text;

    private float m_Time = 0;

    bool PruefeKollisionMitAABB(AABB _Sphere1, AABB _Sphere2)
    {
		// Hier die Kollision berechnen...

		return false;
    }
    
    void OnCollision()
    {
        m_Time += Time.deltaTime;

        m_Text.text = "Collision Time: " + m_Time + " s";
    }
    #endregion

    #region Given By Ur Master
    public GameObject m_Other;

    private AABB m_MyAABBCollider;

    // Use this for initialization
    void Start()
    {
        m_MyAABBCollider = gameObject.GetComponent<AABB>();
    }

    // Update is called once per frame
    void Update()
    {
        bool IsColliding = false;

        AABB OtherBox = m_Other.GetComponent<AABB>();

        if (OtherBox != null)
        {
            IsColliding = PruefeKollisionMitAABB(m_MyAABBCollider, OtherBox);
        }

        if (IsColliding)
        {
            OnCollision();
        }
    }
    #endregion
}

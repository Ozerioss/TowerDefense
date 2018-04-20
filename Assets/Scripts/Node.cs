using UnityEngine;

public class Node : MonoBehaviour {


    public Color hoverColor;
    public Vector3 positionOffset;

    private Renderer _rend;
    private Color initialColor;
    private GameObject turret;


    void Start()
    {
        _rend = GetComponent<Renderer>(); //cashes the mesh renderer
        initialColor = _rend.material.color; // stores initial color of node
    }

    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Tower already built on node");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();

        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }

    // Callback method from unity engine
    void OnMouseEnter()
    {
        _rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        _rend.material.color = initialColor;
    }

}

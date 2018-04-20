using UnityEngine;

public class BuildManager : MonoBehaviour {

    // Singleton pattern
    public static BuildManager instance;

    void Awake()
    {
        instance = this;
    }


    private GameObject turretToBuild;
    public GameObject standardTurretPrefab;

    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }


    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }


}

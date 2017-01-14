using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {
    public static BuildManager instance;
    void Awake() {
        instance = this;
    }
    public GameObject turretStandardPrefap;
    private GameObject turretToBuild;
    public GameObject getTurretToBuild() {
        Debug.Log("c");
        return turretToBuild;
    }
    public void setTurretToBuild(GameObject turret) {
        Debug.Log("b");
        turretToBuild = turret;
    }
}

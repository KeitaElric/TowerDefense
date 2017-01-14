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
        return turretToBuild;
    }
    public void setTurretToBuild(GameObject turret) {
        turretToBuild = turret;
    }
}

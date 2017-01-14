using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurret;

    private BuildManager buildManager;

    private void Start()
    {
        this.buildManager = BuildManager.instance;
    }
	public void SelectStandardTurret()
    {
        this.buildManager.SelectTurretToBuild(standardTurret);
    }
}

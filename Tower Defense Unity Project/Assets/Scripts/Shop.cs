﻿using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {
    private BuildManager buildManager;

    private void Start()
    {
        this.buildManager = BuildManager.instance;
    }
	public void OnStandardTurrentButton_Click()
    {
        Debug.Log("a");
        this.buildManager.setTurretToBuild(this.buildManager.turretStandardPrefap);
    }
}
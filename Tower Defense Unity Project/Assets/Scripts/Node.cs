using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {
    public Color hoverColor;
    private Renderer renderer;
    private Color startColor;
    private BuildManager buildManager;
	// Use this for initialization
	void Start () {
        this.renderer = GetComponent<Renderer>();
        this.startColor = this.renderer.material.color;
        this.buildManager = BuildManager.instance;
    }

    void OnMouseEnter() {
        this.renderer.material.color = hoverColor;
    }
    void OnMouseDown() {
        GameObject turretToBuild = buildManager.getTurretToBuild();
        if (turretToBuild == null)
            return;
        Debug.Log("d");
        Instantiate(turretToBuild, transform.position, transform.rotation);
    }
    void OnMouseExit() {
        this.renderer.material.color = startColor;
    }
}

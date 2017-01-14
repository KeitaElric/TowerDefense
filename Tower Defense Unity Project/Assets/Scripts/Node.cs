using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {
    public Color hoverColor;
    private Renderer renderer;
    private Color startColor;
    private BuildManager buildManager;

    [HideInInspector]
    public GameObject turret;
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
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (turret != null)
        {
            return;
        }
        GameObject turretToBuild = buildManager.getTurretToBuild();
        if (turretToBuild == null)
            return;
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }
    void OnMouseExit() {
        this.renderer.material.color = startColor;
    }
}

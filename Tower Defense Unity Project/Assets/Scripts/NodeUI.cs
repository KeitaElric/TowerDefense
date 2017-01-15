using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeBtn;

    public Text sellCost;

    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            sellCost.text = "$" + target.turretBlueprint.GetSellAmount();
            upgradeBtn.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            sellCost.text = "$" + target.turretBlueprint.GetSellUpgrade();
            upgradeBtn.interactable = false;
        }

        
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}

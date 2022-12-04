using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerCosts ArrowTower;
    public TowerCosts BricoleTower;
    public TowerCosts CrossbowTower;

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStardartTour()
    {
        buildManager.SetTourToBuild(ArrowTower);
    }

    public void PurchaseArbaleteTour()
    {
        buildManager.SetTourToBuild(CrossbowTower);
    }
    public void PurchaseBricole()
    {
        buildManager.SetTourToBuild(BricoleTower);
    }
}
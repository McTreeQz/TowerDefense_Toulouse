using UnityEngine;

public class Shop : MonoBehaviour
{

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStardartTour()
    {
        buildManager.SetTourToBuild(buildManager.standardTowerPrefab);
    }

    public void PurchaseArbaleteTour()
    {
        buildManager.SetTourToBuild(buildManager.arbaleteTowerPrefab);
    }
    public void PurchaseBricole()
    {
        buildManager.SetTourToBuild(buildManager.bricoleTowerPrefab);
    }
}
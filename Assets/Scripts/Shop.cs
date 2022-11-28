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
        buildManager.SetTourToBuild(buildManager.standardTourPrefab);
    }

    public void PurchaseArbaleteTour()
    {
        buildManager.SetTourToBuild(buildManager.arbaleteTourPrefab);
    }
}
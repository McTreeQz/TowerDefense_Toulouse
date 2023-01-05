using UnityEngine;

/// <summary>
/// 
/// Shop
/// 
///      
/// 
/// </summary>


//Ce script permet de g�rer le prix des tours dans l'inspecteur et le prefab associ�. il transmet le prefab au buildManager.
//
//
//
//

public class Shop : MonoBehaviour
{
    public TowerCosts ArrowTower;
    public TowerCosts BricoleTower;
    public TowerCosts CrossbowTower;
   

    [Space]
    public AudioClip towerSelection;
    private AudioSource audioSource;

    private BuildManager buildManager;
    private AlliesSpawner alliesSpawner;

    private void Start()
    {
        buildManager = BuildManager.instance;
        
        
        audioSource = GetComponent<AudioSource>();
    }

    public void PurchaseStardartTour()
    {
        playTrigger();
        buildManager.SetTourToBuild(ArrowTower);
    }

    public void PurchaseArbaleteTour()
    {
        playTrigger();
        buildManager.SetTourToBuild(CrossbowTower);
    }
    public void PurchaseBricole()
    {
        playTrigger();
        buildManager.SetTourToBuild(BricoleTower);
    }
    
    void playTrigger()
    {
        audioSource.PlayOneShot(towerSelection);
    }
}
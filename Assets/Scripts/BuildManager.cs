using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Il y a d�j� un BuildManager dans la sc�ne !");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject standardTowerPrefab;
    public GameObject arbaleteTowerPrefab;
    public GameObject bricoleTowerPrefab;

    private GameObject TourToBuild;
    
    public GameObject GetTourToBuild()
    {
        return TourToBuild;
    }
    public void SetTourToBuild(GameObject turret)
    {
        TourToBuild = turret;
    }
    
}

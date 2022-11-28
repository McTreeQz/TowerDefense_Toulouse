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
            Debug.LogError("Il y a déjà un BuildManager dans la scène !");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject standardTourPrefab;
    public GameObject arbaleteTourPrefab;

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

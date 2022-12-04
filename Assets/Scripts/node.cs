using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node : MonoBehaviour
{
    public GameObject constructionEffect;
    public Color hoverColor;
    public Vector3 positionOffset;
    public GameObject turret;

    private Color startColor;
    private Renderer rend;

    private BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if(!buildManager.canBuild)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Impossible de construire ici, il y a déjà une tourelle.");
            return;
        }
        //if (PlayerStats.money ) 
        // {
        buildManager.buildTowerOn(this);
        //}
    }

    private void OnMouseEnter()
    {
        if (!buildManager.canBuild)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

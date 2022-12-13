using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node : MonoBehaviour
{
    public GameObject constructionEffect;
    public Color hoverColor;
    public Vector3 positionOffset;

    [HideInInspector]
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
    public Vector3 getBuildPosition()
    {
        return transform.position + positionOffset;
    }
    
    private void OnMouseDown()
    {
        

        if (turret != null)
        {
            Debug.Log("Impossible de construire ici, il y a déjà une tourelle.");
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        
        buildManager.buildTowerOn(this);
        
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

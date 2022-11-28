using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node : MonoBehaviour
{
    public GameObject constructionEffect;
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;
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
        if(buildManager.GetTourToBuild() == null)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Impossible de construire ici, il y a déjà une tourelle.");
            return;
        }

        GameObject turretToBuild = buildManager.GetTourToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        GameObject effectIns = (GameObject)Instantiate(constructionEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
    }

    private void OnMouseEnter()
    {
        if (buildManager.GetTourToBuild() == null)
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

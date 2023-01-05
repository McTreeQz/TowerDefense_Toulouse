using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// Node
/// 
///      
/// 
/// </summary>


//L'objectif du script est de g�rer la couleur des nodes mais aussi o� on place les towers et si on peut en placer.
//
//
//
//

public class node : MonoBehaviour
{
    public GameObject constructionEffect;
    public Color hoverColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret; //r�cuper� gr�ce au build manager

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


    // */*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/
    // //                  Bouton                  //
    // */*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/


    private void OnMouseDown()
    {
        

        if (turret != null)
        {
            Debug.Log("Impossible de construire ici, il y a d�j� une tourelle.");
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        
        buildManager.buildTowerOn(this); // contruit la tower selection�e sur la node choisis.
        
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

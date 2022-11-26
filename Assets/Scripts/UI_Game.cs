using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI_Game : MonoBehaviour
{
    PlayerController controls;
    public GameObject tourelle;
    private bool draggable = false;
    Vector3 v3;
    
    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerController();
        controls.Player.CreateDragObject.performed += ctx => Drag();
        controls.Player.CreateDragObject.started += ctx => Create();
        controls.Player.CreateDragObject.canceled += ctx => Drop();
    }
    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }

    public void Create()
    {
        
        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;
        //Debug.Log(pos);
        GameObject Tower = (GameObject)Instantiate(tourelle, transform.position, transform.rotation);
        Debug.Log("click");

    }
    public void Drag()
    {
        draggable = true;
        Debug.Log("Drag");

    }
    public void Drop()
    {
        draggable = false;
        Debug.Log("drop");

    }
    // Update is called once per frame
    void Update()
    {
        
        
        
    }
}



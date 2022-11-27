using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI_Game : MonoBehaviour
{
    PlayerController controls;

    public GameObject tourelle;
    
    private Transform toDrag;

    private float dist;
    private bool draggable = false;

    private Vector3 offset;
    Vector3 v3;
    
    // Start is called before the first frame update
    void Awake()
    {
        
        controls = new PlayerController();
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

        GameObject Tower = (GameObject)Instantiate(tourelle, transform.position, transform.rotation);
        
        
        draggable = true;
        

    }
    public void Drag()
    {
        

    }
    public void Drop()
    {
        draggable = false;
        

    }
    // Update is called once per frame
    void Update()
    {

        if (draggable == true)
        {
            
            Vector3 pos = Input.mousePosition;
            
            Debug.Log(tourelle.transform.position);

            Ray viseur = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;
            if (Physics.Raycast(viseur, out hit))
            {
                Debug.Log(hit.transform.position);
                
                
                
                
                
                
                
                
                
                
                
                
                /*Tower = hit.transform;
                dist = hit.transform.position.z - Camera.main.transform.position.z;
                v3 = new Vector3(pos.x, pos.y, dist);
                v3 = Camera.main.ScreenToWorldPoint(v3);
                offset = toDrag.position - v3;

                if (hit.collider.tag == "World")
                {
                    v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
                    v3 = Camera.main.ScreenToWorldPoint(v3);
                    toDrag.position = v3 + offset;

                    
                }*/
            }
            
        }

    }
}



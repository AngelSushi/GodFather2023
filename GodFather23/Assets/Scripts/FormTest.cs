using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FormTest : MonoBehaviour
{

    [SerializeField] private bool startDrawing;

    [SerializeField] private List<GameObject> models;
    
    private List<GameObject> _points;


    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            models.Add(transform.GetChild(i).gameObject);
        }
    }

    private void OnMouseEnter()
    {
        startDrawing = true;
    }

    private void OnMouseDrag()
    {
        if (startDrawing)
        {
            foreach (Collider2D collider in Physics2D.OverlapCircleAll(FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition), 0.2f)) {
                Debug.Log("name of " + collider.name);
            }
        }
    }

    

    private void OnMouseExit()
    {
        startDrawing = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{

    private List<FormTest> _allForms;
    private FormTest _current;

    private void Start()
    {
        _allForms = FindObjectsOfType<FormTest>().ToList();
        
        _allForms.ForEach(form => form.gameObject.SetActive(false));
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        int random = Random.Range(0, _allForms.Count);
        _current = _allForms[random];
        
        _current.transform.gameObject.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        _current.transform.gameObject.SetActive(false);
    }
}

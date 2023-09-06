using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpawnerp2 : MonoBehaviour
{
    [SerializeField] GameObject _web;
    bool _alreadyAWeb;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            _alreadyAWeb = !_alreadyAWeb;
            NewWeb();
        }
    }
    
    void NewWeb()
    {
        if (_alreadyAWeb)
        {
            Instantiate(_web, transform.position, Quaternion.identity);
        }
    }
}

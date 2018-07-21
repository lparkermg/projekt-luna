using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Core Update loop data.
    private ManagedObjectBehaviour[] _currentObjects;
    private bool _hasLoadedObjects = false;
    private GameObject _managers;
	// Use this for initialization
	void Start ()
	{
	    _managers = gameObject;
	    RefreshObjects();
	}
	
	// Update is called once per frame
	void Update () {
	    if (_hasLoadedObjects)
	    {
	        for (var i = 0; i < _currentObjects.Length; i++)
	        {
	            _currentObjects[i].UpdateMe();
	        }
	    }
	}

    public void RefreshObjects()
    {
        _hasLoadedObjects = false;
        _currentObjects = GetComponents<ManagedObjectBehaviour>();
        for (var i = 0; i < _currentObjects.Length; i++)
        {
            _currentObjects[i].StartMe(_managers);
        }

        _hasLoadedObjects = true;
    }
}

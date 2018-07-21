using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Core Update loop data.
    private ManagedObjectBehaviour[] _currentObjects;
    private bool _hasLoadedObjects = false;

	// Use this for initialization
	void Start ()
	{
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
            _currentObjects[i].StartMe();
        }

        _hasLoadedObjects = true;
    }
}

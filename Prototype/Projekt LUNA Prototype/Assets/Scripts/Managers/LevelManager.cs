using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : ManagedObjectBehaviour
{

    [SerializeField] private LevelController _lunasWorld;
    [SerializeField] private LevelController _leilasWorld;

    [SerializeField] private bool _inLunasWorld = true;

    public override void StartMe(GameObject managers)
    {
        _lunasWorld.gameObject.SetActive(_inLunasWorld);
        _leilasWorld.gameObject.SetActive(!_inLunasWorld);

    }

    public override void UpdateMe(){}

    public void SwapLevels()
    {
        _inLunasWorld = !_inLunasWorld;

        _lunasWorld.gameObject.SetActive(_inLunasWorld);
        _leilasWorld.gameObject.SetActive(!_inLunasWorld);
    }
}

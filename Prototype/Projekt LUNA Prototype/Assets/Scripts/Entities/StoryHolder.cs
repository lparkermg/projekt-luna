using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryHolder : ManagedObjectBehaviour
{
    [SerializeField] private Characters _activationCharacter;
    [SerializeField] private StoryItem[] _storySet;

    public override void StartMe(GameObject managers){}

    public override void UpdateMe(){}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerController>().IsSameCharacter(_activationCharacter))
        {
            //Send story over to UI and disable controls apart from B (Skip) and A (Jump/Next) with PlayerController
        }
    }
}

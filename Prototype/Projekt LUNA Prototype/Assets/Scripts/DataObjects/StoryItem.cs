using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Story Object")]
public class StoryItem : ScriptableObject
{
    public string CharacterName;
    public string StoryContent;
}

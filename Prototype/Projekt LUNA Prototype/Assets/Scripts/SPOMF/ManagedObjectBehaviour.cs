using UnityEngine;
/// <summary>
/// Replacements to the Start() and Update() for a centerally managed loop area.
/// </summary>
public abstract class ManagedObjectBehaviour : MonoBehaviour
{
    public abstract void StartMe();
    public abstract void UpdateMe();
}

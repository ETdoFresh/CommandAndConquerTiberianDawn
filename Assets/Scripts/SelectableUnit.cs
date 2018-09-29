using UnityEngine;

[RequireComponent(typeof(Unit))]
public class SelectableUnit : MonoBehaviour
{
    public Projector projector = null;

    private void OnValidate()
    {
        projector = projector ?? GetComponentInChildren<Projector>(true);
    }

    public void Select() { projector.enabled = true; }
    public void Deselect() { projector.enabled = false; }
}
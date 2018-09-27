using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : ScriptableObject, IEnumerable<Unit>
{
    public List<Unit> selection = new List<Unit>();

    private void OnEnable()
    {
        Clear();
    }

    public void Add(Unit item)
    {
        selection.Add(item);
        item.GetComponentInChildren<Projector>(true)?.gameObject.SetActive(true);
    }

    public void Remove(Unit item)
    {
        item.GetComponentInChildren<Projector>()?.gameObject.SetActive(false);
        selection.Remove(item);
    }
    public void Clear()
    {
        foreach (var unit in selection)
            unit.GetComponentInChildren<Projector>()?.gameObject.SetActive(false);

        selection.Clear();
    }

    public IEnumerator<Unit> GetEnumerator() => selection.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => selection.GetEnumerator();
}

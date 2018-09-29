using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : ScriptableObject, IEnumerable<Unit>
{
    public List<Unit> selection = new List<Unit>();

    public int Count { get { return selection.Count; } }

    private void OnEnable()
    {
        Clear();
    }

    public void Add(Unit item)
    {
        selection.Add(item);
    }

    public void Add(SelectableUnit item)
    {
        Add(item.GetComponent<Unit>());
    }

    public void Remove(Unit item)
    {
        selection.Remove(item);
    }
    public void Clear()
    {
        selection.Clear();
    }

    public IEnumerator<Unit> GetEnumerator() => selection.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => selection.GetEnumerator();
}

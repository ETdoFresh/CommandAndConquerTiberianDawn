using UnityEngine;

public class TrackHitPoints : MonoBehaviour
{
    public UnitHealth unitHealth;
    public RectTransform bar;
    public float maxBarSize = 0.4f;

    private void Start()
    {
        if (bar) maxBarSize = bar.sizeDelta.x;
    }

    private void Update()
    {
        if (!unitHealth || !bar) return;

        var hitpoints = unitHealth.hitPoints;
        var maxHitPoints = unitHealth.unit.hitPoints;
        var percentHealth = hitpoints / maxHitPoints;
        var size = bar.sizeDelta;
        size.x = maxBarSize * percentHealth;
        bar.sizeDelta = size;
    }
}

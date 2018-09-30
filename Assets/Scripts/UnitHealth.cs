using UnityEngine;

[RequireComponent(typeof(Unit))]
public class UnitHealth : MonoBehaviour
{
    public Unit unit;
    public float hitPoints;

    private void OnValidate()
    {
        if (Application.isPlaying) return;
        unit = unit ?? GetComponent<Unit>();
        if (hitPoints == 0) hitPoints = unit.hitPoints;
    }

    public void Update()
    {
        if (hitPoints <= 0) Die();
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
    }

    private void Die()
    {
        hitPoints = 0;
        gameObject.SetActive(false);
    }
}

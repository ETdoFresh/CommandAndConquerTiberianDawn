using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Unit")]
    public UnitType unitType;
    public Faction affiliation;
    public string role;
    public Weapon weapon;
    public ProducerType[] requiredToBuild;

    [Header("Properties")]
    public HitPoints hitPoints;
    public ArmorType armorType;

    [Header("Production")]
    public Cost cost;
    public BuildTime buildTime;
    public ProducerType produceBy;

    [Header("Combat")]
    public GroundAttack groundAttack;
    public AirAttack airAttack;
    public Cooldown coolDown;
    public Speed speed;
    public AttackRange attackRange;
    public SightRange sightRange;
}

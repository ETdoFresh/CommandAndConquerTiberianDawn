using UnityEngine;
using UnityEngine.Serialization;

public class Unit : MonoBehaviour
{
    [Header("Unit")]
    public UnitType unitType;
    public Faction affiliation;
    public string role;
    public Weapon weapon;
    public string requiredToBuild;

    [Header("Properties")]
    public FloatValue hitPoints;
    public string armorType;

    [Header("Production")]
    public FloatValue cost;
    public FloatValue buildTime;
    public string produceBy;

    [Header("Combat")]
    public FloatValue groundAttack;
    public FloatValue airAttack;
    public FloatValue coolDown;
    public FloatValue speed;
    public FloatValue attackRange;
    public FloatValue sightRange;
}

using UnityEngine;
using UnityEngine.AI;

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

    [SerializeField] private NavMeshAgent navMeshAgent;

    private void OnValidate()
    {
        navMeshAgent = navMeshAgent ?? GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (navMeshAgent) navMeshAgent.speed = speed;
    }
}

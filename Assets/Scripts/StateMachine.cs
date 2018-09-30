using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Unit), typeof(NavMeshAgent))]
public class StateMachine : MonoBehaviour
{
    public bool isTargetTransform;
    public Transform targetTransform;
    public Vector3 targetVector;
    public Vector3 Target { get { return isTargetTransform ? targetTransform ? targetTransform.position : transform.position : targetVector; } }

    public Unit unit;
    public NavMeshAgent navMeshAgent;

    public enum State { Idle, Move, Attack }
    public State state = State.Idle;

    public float lastAttackTime;

    public GameObject muzzlePrefab;
    public GameObject sparksPrefab;
    public Transform muzzleTransform;

    private void OnValidate()
    {
        unit = unit ?? GetComponent<Unit>();
        navMeshAgent = navMeshAgent ?? GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navMeshAgent.speed = unit.speed / 6;
        switch (state)
        {
            case State.Idle:
                break;
            case State.Move:
                Continue(); break;
            case State.Attack:
                ContinueAttack(); break;
        }
    }

    public void MoveTo(Vector3 destination)
    {
        state = State.Move;
        SetDestination(destination);
    }

    public void MoveTo(Transform destination)
    {
        state = State.Move;
        SetDestination(destination);
    }

    public void AttackTo(Vector3 destination)
    {
        state = State.Attack;
        SetDestination(destination);
    }

    public void AttackTo(Transform destination)
    {
        state = State.Attack;
        SetDestination(destination);
    }

    private void SetDestination(Vector3 destinaton)
    {
        isTargetTransform = false;
        targetVector = destinaton;
        navMeshAgent.SetDestination(Target);
    }

    private void SetDestination(Transform destination)
    {
        isTargetTransform = true;
        targetTransform = destination;
        navMeshAgent.SetDestination(Target);
    }

    private void Continue()
    {
        navMeshAgent.updatePosition = true;
        navMeshAgent.SetDestination(Target);
    }

    private void ContinueAttack()
    {
        var distance = Vector3.Distance(transform.position, Target);
        if (distance > unit.attackRange)
            Continue();
        else
        {
            Stop();
            Attack();
        }
    }

    private void Stop()
    {
        navMeshAgent.updatePosition = false;
        navMeshAgent.nextPosition = transform.position;
    }

    private void Attack()
    {
        var attackEndTime = lastAttackTime + unit.coolDown / 30;
        if (Time.time <= attackEndTime) return;

        lastAttackTime = Time.time;
        if (isTargetTransform)
        {
            if (targetTransform.gameObject.activeSelf)
                targetTransform.GetComponent<UnitHealth>()?.TakeDamage(unit.groundAttack);
            else
            {
                MoveTo(transform.position);
                return;
            }
        }

        var muzzle = Instantiate(muzzlePrefab, muzzleTransform.position, muzzleTransform.rotation);
        var sparks = Instantiate(sparksPrefab, Target, Quaternion.identity);
        Destroy(muzzle, 3);
        Destroy(sparks, 3);
    }
}

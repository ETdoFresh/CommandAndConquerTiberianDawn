using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ClickAndMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;

    private void OnValidate()
    {
        navMeshAgent = navMeshAgent ?? GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                navMeshAgent.SetDestination(hit.point);
        }
    }
}

using UnityEngine;
using UnityEngine.AI;

public class SelectAndMove : MonoBehaviour
{
    public UnitSelection selection;
    public RaycastHit[] results = new RaycastHit[10];

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selection.Clear();
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);   
            int count = Physics.RaycastNonAlloc(ray, results);
            for(int i = 0; i < count; i++)
            {
                var result = results[i];
                var unit = result.collider.GetComponent<Unit>();
                if (unit)
                {
                    selection.Add(unit);
                    return;
                }
            }
        }

        if (Input.GetMouseButton(1))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.RaycastNonAlloc(ray, results);
            foreach (var result in results)
            {
                var ground = result.collider.GetComponent<Ground>();
                if (ground)
                {
                    foreach(var unit in selection)
                    {
                        unit.GetComponent<NavMeshAgent>()?.SetDestination(result.point);
                    }
                    return;
                }
            }
        }
    }
}

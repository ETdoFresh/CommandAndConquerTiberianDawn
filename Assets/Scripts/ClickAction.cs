using UnityEngine;

[RequireComponent(typeof(SelectUnits))]
public class ClickAction : MonoBehaviour
{
    public enum Mode { Move, Attack }
    public Mode mode = Mode.Move;
    public SelectUnits selectUnits;
    private UnitSelection Selection { get { return selectUnits.selection; } }

    private void OnValidate()
    {
        selectUnits = selectUnits ?? GetComponent<SelectUnits>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
            switch (mode)
            {
                case Mode.Move:
                    Move(); break;
                case Mode.Attack:
                    Attack();  break;
            }

        if (Input.GetButtonDown("Jump"))
            mode = mode == Mode.Move ? Mode.Attack : Mode.Move;
    }

    private void Move()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var results = Physics.RaycastAll(ray);
        foreach (var result in results)
        {
            if (result.collider.GetComponent<Unit>())
            {
                foreach (var unit in Selection)
                    unit.GetComponent<StateMachine>()?.MoveTo(result.transform);
                return;
            }
            if (result.collider.GetComponent<Ground>())
            {
                foreach (var unit in Selection)
                    unit.GetComponent<StateMachine>()?.MoveTo(result.point);
                return;
            }
        }
    }

    private void Attack()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var results = Physics.RaycastAll(ray);
        foreach (var result in results)
        {
            if (result.collider.GetComponent<Unit>())
            {
                foreach (var unit in Selection)
                    unit.GetComponent<StateMachine>()?.AttackTo(result.transform);
                return;
            }
            if (result.collider.GetComponent<Ground>())
            {
                foreach (var unit in Selection)
                    unit.GetComponent<StateMachine>()?.AttackTo(result.point);
                return;
            }
        }
    }
}

using UnityEngine;

public abstract class FloatValue : ScriptableObject
{
    [SerializeField] private float value;

    public float Value { get { return value; } set { this.value = value; } }

    public static implicit operator float (FloatValue floatValue)
    {
        return floatValue ? floatValue.value : float.NaN;
    }
}

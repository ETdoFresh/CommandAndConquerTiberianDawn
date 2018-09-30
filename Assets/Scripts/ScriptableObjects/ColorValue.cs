using UnityEngine;

public abstract class ColorValue : ScriptableObject
{
    [SerializeField] private Color value;

    public Color Value { get { return value; } set { this.value = value; } }

    public static implicit operator Color(ColorValue colorValue)
    {
        return colorValue.value;
    }
}

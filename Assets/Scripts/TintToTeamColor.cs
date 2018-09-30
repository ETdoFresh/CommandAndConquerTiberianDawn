using UnityEngine;

public class TintToTeamColor : MonoBehaviour
{
    public Material materialToTint;
    public TeamColor teamColor;

    private void Start() => Tint();

    private void Tint()
    {
        if (!materialToTint || !teamColor)
            return;

        foreach(var renderer in GetComponentsInChildren<Renderer>())
        {
            if (renderer.sharedMaterial == materialToTint)
                renderer.material.color = teamColor;
        }
    }
}
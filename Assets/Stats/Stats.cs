using UnityEngine;

[CreateAssetMenu(fileName = "New Stat", menuName = "Stats/Stats", order = 1)]
public class Stats : ScriptableObject
{
    public float velocidad;
    public float rotacion;
    public float ataque;
    public float maxCuerda;
}

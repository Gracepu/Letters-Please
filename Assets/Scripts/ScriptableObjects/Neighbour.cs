using UnityEngine;

[CreateAssetMenu(fileName = "Neighbours", menuName = "ScriptableObjects/Neighbour", order = 1)]
public class Neighbour : ScriptableObject {
    public Phrase[] liking;
}

using UnityEngine;

[CreateAssetMenu(fileName = "Phrases", menuName = "ScriptableObjects/Phrase", order = 1)]
public class Phrase : ScriptableObject {
    public int type;
    public string phrase;
}

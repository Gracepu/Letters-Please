using UnityEngine;

[CreateAssetMenu(fileName = "Letters", menuName = "ScriptableObjects/Letter", order = 1)]
public class Letters : ScriptableObject {
    public Phrase[] letterMessage = new Phrase[4];
    public Sprite letterImage;
}
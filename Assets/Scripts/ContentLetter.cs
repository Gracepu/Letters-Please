using UnityEngine;

public class ContentLetter : MonoBehaviour {
    public Letters letter;
    
    public int[] GetMessageTypes() {
        int[] types = new int[4];
        for (int i = 0; i < letter.letterMessage.Length; i++) {
            types[i] = letter.letterMessage[i].type;
        }
        return types;
    }
}

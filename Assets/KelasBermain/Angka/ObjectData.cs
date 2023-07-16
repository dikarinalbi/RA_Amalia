using UnityEngine;

[CreateAssetMenu(fileName = "New Object Data", menuName = "Object Hide and Seek/Object Data")]
public class ObjectData : ScriptableObject
{
    public Sprite image;
    public Sprite[] answerImages;
    public int correctAnswerIndex;
    public AudioClip voiceover;
}

using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Question", menuName = "Quiz/Question")]
public class QuizData : ScriptableObject
{
    public Sprite image;
    public Sprite[] answerImages;
    public int correctAnswerIndex;
    public AudioClip voiceover;
}
using UnityEngine;

[CreateAssetMenu(fileName = "ScoringImageMap", menuName = "QuizGame/Scoring Image Map")]
public class ScoringImageMap : ScriptableObject
{
    [System.Serializable]
    public struct ScoreImagePair
    {
        public int score;
        public Sprite image;
    }

    [System.Serializable]
    public struct LifelineImagePair
    {
        public int lifelines;
        public Sprite image;
    }

    public ScoreImagePair[] scoreImagePairs;
    public LifelineImagePair[] lifelineImagePairs;
}

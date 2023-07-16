using UnityEngine;
using UnityEngine.UI;

public class ScoreImageChanger : MonoBehaviour
{
    public ScoringImageMap scoringImageMap;
    public Image imageComponent;
    public int currentScore;

    private void Start()
    {
        UpdateImage();
    }

    public void SetScore(int score)
    {
        currentScore = score;
        UpdateImage();
    }

    private void UpdateImage()
    {
        if (scoringImageMap == null || imageComponent == null)
            return;

        foreach (var pair in scoringImageMap.scoreImagePairs)
        {
            if (currentScore >= pair.score)
            {
                imageComponent.sprite = pair.image;
                return;
            }
        }
    }
}

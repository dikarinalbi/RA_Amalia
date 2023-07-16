using UnityEngine;
using UnityEngine.UI;

public class ScoreReport : MonoBehaviour
{
    public Image scoreResultImagePanelHuruf;
    public Image scoreResultImagePanelAngka;

    public Sprite scoreA_Huruf;
    public Sprite scoreB_Huruf;
    public Sprite scoreC_Huruf;
    public Sprite scoreD_Huruf;

    public Sprite scoreA_Angka;
    public Sprite scoreB_Angka;
    public Sprite scoreC_Angka;
    public Sprite scoreD_Angka;

    private void Start()
    {
        // Retrieve the score value from PlayerPrefs
        int scoreHuruf = PlayerPrefs.GetInt("ScoreHuruf");
        int scoreAngka = PlayerPrefs.GetInt("ScoreAngka");
        Debug.Log("Score Hurufnya" + scoreHuruf + " dan score Angkanya " +  scoreAngka);

        // Display the score value Huruf
        if (scoreHuruf == 5)
        {
            scoreResultImagePanelHuruf.sprite = scoreA_Huruf;
        }
        else if (scoreHuruf == 3 || scoreHuruf == 4)
        {
            scoreResultImagePanelHuruf.sprite = scoreB_Huruf;
        }
        else if (scoreHuruf == 1 || scoreHuruf == 2)
        {
            scoreResultImagePanelHuruf.sprite = scoreC_Huruf;
        }
        else if (scoreHuruf == 0)
        {
            scoreResultImagePanelHuruf.sprite = scoreD_Huruf;
        }

        // Display the score value Angka
        if (scoreAngka == 5)
        {
            scoreResultImagePanelAngka.sprite = scoreA_Angka;
        }
        else if (scoreAngka == 3 || scoreAngka == 4)
        {
            scoreResultImagePanelAngka.sprite = scoreB_Angka;
        }
        else if (scoreAngka == 1 || scoreAngka == 2)
        {
            scoreResultImagePanelAngka.sprite = scoreC_Angka;
        }
        else if (scoreHuruf == 0)
        {
            scoreResultImagePanelAngka.sprite = scoreD_Angka;
        }
    }
}


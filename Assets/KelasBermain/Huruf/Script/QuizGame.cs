using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizGame : MonoBehaviour
{
    public QuizData[] questions; // Array of quiz questions
    public Image imagePanel; // Reference to the image panel
    public RectTransform[] answerButtons; // Array of answer buttons (RectTransforms)


    public int currentQuestionIndex; // Index of the current question
    private int score = 0;
    private int lifelines = 3;

    public ScoringImageMap scoringImageMap; // Reference to the scoring image map
    public Image scoreImage;
    public Image lifelineImage;
    public Image scoreResultImagePanel;

    public AudioClip kamuPintar;
    public AudioClip kamuHebat, yahSalah;
    public AudioClip Opening;

    public Sprite scoreA, scoreB, scoreC, scoreD;
    public Sprite benar, salah;


    public Button replayButton; // Reference to the replay button
    public AudioSource voiceoverAudioSource;

    private bool isDragging; // Flag indicating if an answer button is being dragged
    private RectTransform draggedButton; // Reference to the currently dragged answer button

    public GameObject scoringResult;

    private void Start()
    {
        StartQuiz();
    }

    public void StartQuiz()
    {
        currentQuestionIndex = 0;
        score = 0;
        lifelines = 3;
        ShuffleQuestions();
        LoadQuestion();
        UpdateScoreImage();
        UpdateLifelineImage();

        voiceoverAudioSource.clip = Opening;
        voiceoverAudioSource.Play();

        replayButton.onClick.AddListener(ReplayVoiceover);
    }

    public void ResetQuiz()
    {
        currentQuestionIndex = 0;
        score = 0;
        lifelines = 3;
        ShuffleQuestions();
        LoadQuestion();
        UpdateScoreImage();
        UpdateLifelineImage();
        scoringResult.SetActive(false);
    }

    private void ShuffleQuestions()
    {
        // Fisher-Yates shuffle algorithm
        for (int i = 0; i < questions.Length - 1; i++)
        {
            int randomIndex = Random.Range(i, questions.Length);
            QuizData temp = questions[randomIndex];
            questions[randomIndex] = questions[i];
            questions[i] = temp;
        }
    }

    private void PlayVoiceover(AudioClip clip)
    {
        voiceoverAudioSource.clip = clip;
        voiceoverAudioSource.Play();
    }

    public void ReplayVoiceover()
    {
        if (voiceoverAudioSource.isPlaying)
        {
            voiceoverAudioSource.Stop();
        }

        AudioClip voiceoverClip = questions[currentQuestionIndex].voiceover;
        if (voiceoverClip != null)
        {
            PlayVoiceover(voiceoverClip);
        }
    }

    private void LoadQuestion()
    {
        // Display the image associated with the current question
        imagePanel.sprite = questions[currentQuestionIndex].image;

        // Set the image of the answer buttons
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Image>().sprite = questions[currentQuestionIndex].answerImages[i];
        }

        // Stop the voiceover if it's currently playing
        if (voiceoverAudioSource.isPlaying)
        {
            voiceoverAudioSource.Stop();
        }

        // Play the voiceover, if available
        AudioClip voiceoverClip = questions[currentQuestionIndex].voiceover;
        if (voiceoverClip != null)
        {
            if (currentQuestionIndex == 0)
            {
                StartCoroutine(PlayQuestionVoiceoverDelayed(voiceoverClip));
            }
            else
            {
                voiceoverAudioSource.clip = voiceoverClip;
                voiceoverAudioSource.Play();
            }
        }
    }

    private IEnumerator PlayQuestionVoiceoverDelayed(AudioClip clip)
    {
        // Wait for a short delay before playing the voiceover
        yield return new WaitForSeconds(5f);

        voiceoverAudioSource.clip = clip;
        voiceoverAudioSource.Play();
    }

    public void OnBeginDragAnswerButton(RectTransform buttonRectTransform)
    {
        if (!isDragging)
        {
            draggedButton = buttonRectTransform;
            isDragging = true;
        }
    }

    public void OnEndDragAnswerButton()
    {
        if (isDragging && draggedButton != null)
        {
            isDragging = false;
            draggedButton = null;
        }
    }

    public void OnDropQuestionImage(RectTransform buttonRectTransform)
    {
        if (isDragging && draggedButton != null && draggedButton == buttonRectTransform)
        {
            Checked(buttonRectTransform);

        }
    }

    public void Checked(RectTransform buttonRectTransform)
    {
        // Check if the dropped answer button matches the correct answer
        int droppedButtonIndex = GetDroppedButtonIndex(buttonRectTransform);
        bool isCorrect = questions[currentQuestionIndex].correctAnswerIndex == droppedButtonIndex;

        // Show feedback based on the correctness of the answer
        if (isCorrect)
        {
            Debug.Log("Correct answer!");
            score++;
            imagePanel.sprite = benar;
            // Play Audio A (correct answer audio)
            AudioManager.Instance.PlayCorrectAnswerAudio();
            
            // Delay before moving to the next question
            StartCoroutine(DelayedNextQuestion());
        }
        else
        {
            Debug.Log("Wrong answer!");
            lifelines--;
            imagePanel.sprite = salah;
            // Play Audio B (wrong answer audio)
            AudioManager.Instance.PlayWrongAnswerAudio();

            // Move to the next question immediately
            StartCoroutine(DelayedNextQuestion());
        }

        UpdateScoreImage();
        UpdateLifelineImage();
    }

    private IEnumerator DelayedNextQuestion()
    {
        // Wait for the correct answer audio to finish playing
        yield return new WaitForSeconds(AudioManager.Instance.correctAnswerAudioSource.clip.length);

        // Move to the next question
        MoveToNextQuestion();
    }

    private void MoveToNextQuestion()
    {
        // Move to the next question
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            LoadQuestion();
        }
        else
        {
            EndQuiz();
        }
    }

    private void UpdateScoreImage()
    {
        if (scoringImageMap == null || scoreImage == null)
            return;

        foreach (var pair in scoringImageMap.scoreImagePairs)
        {
            if (score == pair.score)
            {
                scoreImage.sprite = pair.image;
                return;
            }
        }
    }

    private void UpdateLifelineImage()
    {
        if (scoringImageMap == null || lifelineImage == null)
            return;

        foreach (var pair in scoringImageMap.lifelineImagePairs)
        {
            if (lifelines == pair.lifelines)
            {
                lifelineImage.sprite = pair.image;
                return;
            }
        }
    }


    public int GetDroppedButtonIndex(RectTransform buttonRectTransform)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (answerButtons[i] == buttonRectTransform)
            {
                return i;
            }
        }
        return -1;
    }

    private void EndQuiz()
    {
        // Quiz finished, perform any necessary actions
        Debug.Log("Quiz finished!");
        Debug.Log("Score: " + score);
        Debug.Log("Lifelines: " + lifelines);
        scoringResult.SetActive(true);

        PlayerPrefs.DeleteKey("ScoreHuruf");
        PlayerPrefs.SetInt("ScoreHuruf", score);
        PlayerPrefs.Save();

        if (score == 5 && lifelines > 0)
        {
            scoreResultImagePanel.sprite = scoreA;
            voiceoverAudioSource.clip = kamuPintar;
            voiceoverAudioSource.Play();
        }
        else if (score == 3 || score == 4 && lifelines > 0)
        {
            scoreResultImagePanel.sprite = scoreB;
            voiceoverAudioSource.clip = kamuHebat;
            voiceoverAudioSource.Play();
        }
        else if (score == 1 || score == 2 && lifelines > 0)
        {
            scoreResultImagePanel.sprite = scoreC;
            voiceoverAudioSource.clip = kamuHebat;
            voiceoverAudioSource.Play();
        }
        else if (score == 0 || lifelines == 0)
        {
            scoreResultImagePanel.sprite = scoreD;
            voiceoverAudioSource.clip = yahSalah;
            voiceoverAudioSource.Play();
        }

    }
}


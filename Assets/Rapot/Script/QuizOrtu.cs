using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class QuizOrtu : MonoBehaviour
{
    public ObjectData[] questions; // Array of quiz questions
    public Image imagePanel; // Reference to the image panel
    public RectTransform[] answerButtons; // Array of answer buttons (RectTransforms)
    public int currentQuestionIndex; // Index of the current question
    public GameObject salahjawab;
    private bool saving;
    private string showStartMessageDataName = "savemenu";
    public GameObject MainMenu;

    public void Start(){
        saving = PlayerPrefs.GetInt(showStartMessageDataName, 1) == 1;
        StartQuiz();
        salahjawab.SetActive(false);
    }

    public void SaveState(){
        if (!saving)
        {
            PlayerPrefs.SetInt(showStartMessageDataName, 0);//write bool in memory as an integer
        }
        MainMenu.SetActive(false);
    }

    public void StartQuiz()
    {
        currentQuestionIndex = 0;
        
        ShuffleQuestions();
        LoadQuestion();
    }

    private void ShuffleQuestions()
    {
        // Fisher-Yates shuffle algorithm
        for (int i = 0; i < questions.Length - 1; i++)
        {
            int randomIndex = Random.Range(i, questions.Length);
            ObjectData temp = questions[randomIndex];
            questions[randomIndex] = questions[i];
            questions[i] = temp;
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

    }
    public void Checked(int buttonIndex)
    {
        bool isCorrect = questions[currentQuestionIndex].correctAnswerIndex == buttonIndex;
        if (isCorrect)
        {
            Debug.Log("Correct answer!");
            SceneLoader.sceneLoader.SceneLoaders("Rapot");
        }
        else
        {
            Debug.Log("Wrong answer!");
            salahjawab.SetActive(true);

        }
    }

    
}

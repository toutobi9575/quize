using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text questionDisplayText;
    public Text scoreDisplayText;
    public Text timeRemainingDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;

    private DateController dateController;
    private RoundDate currentRoundDate;
    private QuestionDate[] questionPool;

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();
    private int questionCount=1;

	// Use this for initialization
	void Start ()
    {
        dateController = FindObjectOfType<DateController>();
        currentRoundDate = dateController.GetCurrentRoundDate();
        questionPool = currentRoundDate.questions;
        timeRemaining = currentRoundDate.timeLimitInSeconds;
        UpdateTimeRemainingDisplay();

        playerScore = 0;
        questionIndex = Random.Range(0,25);

        ShowQuestion();
        isRoundActive = true;

	}

    private void ShowQuestion()
    {
        RemoveAnswerButtons();
        QuestionDate questionDate = questionPool[questionIndex];
        questionDisplayText.text = questionDate.questionText;

        for(int i=0;i<questionDate.answers.Length;i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            answerButtonGameObject.name = i.ToString();
            answerButtonGameObjects.Add(answerButtonGameObject);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionDate.answers[i]);
        }
    }

    private void RemoveAnswerButtons()
    {
        while(answerButtonGameObjects. Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if(isCorrect)
        {
            playerScore += currentRoundDate.pointsAddedForCorrectAnswer;
            scoreDisplayText.text = "score: " + playerScore.ToString();
        }

        if (questionCount < 5) 
        {
            questionIndex++;
            questionCount++;
            ShowQuestion();
        }
        else
        {
            EndRound();
            
        }
    }

    public void EndRound()
    {
        isRoundActive = false;

        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(isRoundActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();

            if (timeRemaining <= 0f)
            {
                EndRound();
            }
        }
		
	}
}

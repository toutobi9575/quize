using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjRotation : MonoBehaviour
{

    public Text answerText;
    public SerialHandler _SerialHandler;
    private AnswerDate answerDate;
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }


    public void Setup(AnswerDate date)
    {
        answerDate = date;
        answerText.text = answerDate.answerText;
    }
    void Update()
    {
        objRotation(_SerialHandler.message_);
    }

    public void objRotation(string message)
    {
        string[] a;
        

        a = message.Split("="[0]);
        if (a.Length != 2) return;
        int v = int.Parse(a[1]);
 
       
            switch (a[0])
            {
                case "zero":
                gameController.AnswerButtonClicked(answerDate.isCorrect);
                Debug.Log("0");
                break;
                case "one":
                gameController.AnswerButtonClicked(answerDate.isCorrect);
                Debug.Log("1");
                break;
                case "two":
                gameController.AnswerButtonClicked(answerDate.isCorrect);
                Debug.Log("2");
                break;
                case "three":
                gameController.AnswerButtonClicked(answerDate.isCorrect);
                Debug.Log("3");
                break;
            case "none":
                Debug.Log("9");
                break;
        }

        }
    
}



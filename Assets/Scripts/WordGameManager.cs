using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordGameManager : QuizManager<WordPair>
{
    [SerializeField] private TextMeshProUGUI wordPrompt;

    private bool isAnswerInEnglish;

    public override void CheckAnswer()
    {
        base.CheckAnswer();

        if (enteredAns.Equals(""))
        {
            textManager.ShowMissingAnswerMessage();
        }
        else if (currentItem
            .CheckAnswer(enteredAns, isAnswerInEnglish))
        {
            textManager.ShowCorrectMessage();
            isQuestionSolved = true;
            SetInputToReadonly(true);
            CheckForQuizEnd();
        }
        else
        {
            textManager.ShowWrongAnswerMessage();
        }
    }

    public override void MoveToNextQuestion()
    {
        base.MoveToNextQuestion();
        SetNextPrompt();
    }

    public override void ShowHint()
    {
        string hint = isAnswerInEnglish ? currentItem.english : currentItem.german;
        textManager.SetHint(hint);
    }

    protected override void Initialise()
    {
        base.Initialise();
        isAnswerInEnglish = PersistentData.IsAnswerInEnglish;
        SetNextPrompt();
    }

    protected override void HandleTab()
    {
        if (selectedInputField != playerInput)
        {
            playerInput.Select();
        }
    }

    protected override void ShowAnswer()
    {
        base.ShowAnswer();

        if (isAnswerInEnglish)
        {
            playerInput.text = "<color=red>" + currentItem.german + "</color>";
        } 
        else
        {
            playerInput.text = "<color=red>" + currentItem.english + "</color>";
        }
    }

    private void SetNextPrompt()
    {
        if (isAnswerInEnglish)
        {
            wordPrompt.text = currentItem.german;
        }
        else
        {
            wordPrompt.text = currentItem.english;
        }
    }
}

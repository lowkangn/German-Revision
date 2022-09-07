using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NounGameManager : QuizManager<Item>
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_InputField pluralInput;

    private string prevPluralAns = "";

    public override void CheckAnswer()
    {
        base.CheckAnswer();
        string[] singularSpliced = enteredAns.Split(" ");
        string pluralAns = pluralInput.text.Trim();
        string[] pluralSpliced = pluralAns.Split(" ");

        bool isSingleEmpty = enteredAns.Equals("");
        bool isPluralEmpty = pluralAns.Equals("");

        if (isSingleEmpty && isPluralEmpty)
        {
            textManager.ShowMissingAnswerMessage();
        }
        else if ((!isSingleEmpty && singularSpliced.Length == 1) 
            || (!isPluralEmpty && pluralSpliced.Length == 1))
        {
            textManager.ShowMissingArticleMessage();
        }
        else if ((!isPluralEmpty && !IsNounCapitalised(pluralSpliced))
            || (!isSingleEmpty && !IsNounCapitalised(singularSpliced)))
        {
            textManager.ShowUncapitalisedNounMessage();
        }
        else if (currentItem
            .CheckAnswer(enteredAns, pluralAns))
        {
            MarkAnswerAsCorrect();
        }
        else
        {
            textManager.ShowWrongAnswerMessage();
        }
    }

    public override void MoveToNextQuestion()
    {
        base.MoveToNextQuestion();
        image.sprite = currentItem.image;
    }

    public override void ShowHint()
    {
        textManager.SetHint(currentItem.image.texture.name);
    }

    protected override void Initialise()
    {
        base.Initialise();
        image.sprite = currentItem.image;
    }

    protected override void HandleTab()
    {
        if (selectedInputField == playerInput)
        {
            pluralInput.Select();
        }
        else
        {
            playerInput.Select();
        }
    }

    protected override void SetInputToReadonly(bool isReadonly)
    {
        base.SetInputToReadonly(isReadonly);
        pluralInput.readOnly = isReadonly;
    }

    protected override void ClearInput()
    {
        base.ClearInput();
        pluralInput.text = "";
    }

    protected override void ShowAnswer()
    {
        base.ShowAnswer();

        prevPluralAns = pluralInput.text;
        playerInput.text = "<color=red>" + currentItem.singularForm + "</color>";
        pluralInput.text = "<color=red>" + currentItem.pluralForm + "</color>";
    }

    protected override void HideAnswer()
    {
        base.HideAnswer();

        pluralInput.text = prevPluralAns;
    }

    private bool IsNounCapitalised(string[] spliced)
    {
        return spliced.Length > 1 && Char.IsUpper(spliced[1][0]);
    }

    private void MarkAnswerAsCorrect()
    {
        textManager.ShowCorrectMessage();
        isQuestionSolved = true;
        SetInputToReadonly(true);
        CheckForQuizEnd();
    }
}

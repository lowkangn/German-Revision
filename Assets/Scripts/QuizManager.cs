using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public abstract class QuizManager<T> : MonoBehaviour
{
    [SerializeField] protected TMP_InputField playerInput;
    [SerializeField] protected TextManager textManager;
    [SerializeField] protected UiEventManagerScriptableObject uiEventManager;

    [Header("Answers")]
    [SerializeField] protected AnswerListScriptableObject<T> itemList;

    protected List<T> items;
    protected T currentItem;
    protected int currentIndex = 0;
    protected int itemCount;

    protected TMP_InputField selectedInputField;
    protected bool isQuestionSolved = false;
    protected bool isAnswerShown = false;
    protected string prevSingularAns = "";
    protected string enteredAns = "";

    private void Start()
    {
        Initialise();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && selectedInputField != null)
        {
            HandleTab();
        } 
        else if (Input.GetKeyDown("return") && !isAnswerShown)
        {
            HandleEnter();
        }
    }

    public virtual void CheckAnswer()
    {
        enteredAns = playerInput.text.Trim();
    }

    public void SelectInputField(TMP_InputField inputField)
    {
        selectedInputField = inputField;
    }

    public void AddUmlaut(string umlaut)
    {
        if (selectedInputField != null && !isAnswerShown && !isQuestionSolved)
        {
            int caretPosition = selectedInputField.caretPosition;
            selectedInputField.text = selectedInputField
                .text.Insert(caretPosition, umlaut);
            selectedInputField.Select();
            selectedInputField.caretPosition = caretPosition + 1;
        }
    }

    public void CheckForQuizEnd()
    {
        uiEventManager.OnCorrectAnswer(currentIndex == itemCount - 1);
    }

    public virtual void MoveToNextQuestion()
    {
        currentIndex = (currentIndex + 1) % itemCount;
        uiEventManager.OnNextQuestion(currentIndex == itemCount - 1);
        isQuestionSolved = false;
        currentItem = items[currentIndex];

        ClearInput();
        textManager.ClearAllMessages();
        StartCoroutine(SelectFirstInputField());
    }

    public void ResetQuiz()
    {
        GeneralUtility.Shuffle(items);
        currentIndex = 0;
        MoveToNextQuestion();
    }

    public void ToggleAnswers()
    {
        if (!isAnswerShown)
        {
            ShowAnswer();
        }
        else
        {
            HideAnswer();
        }
        uiEventManager.OnHintToggled(isAnswerShown);
    }

    public virtual void ShowHint() { }

    protected virtual void Initialise()
    {
        items = GeneralUtility.CopyList(itemList.items);
        GeneralUtility.Shuffle(items);
        itemCount = items.Count;
        currentItem = items[currentIndex];
    }

    protected virtual void HandleTab() { }

    protected void HandleEnter() {

        if (!isQuestionSolved)
        {
            CheckAnswer();
        }
        else if (currentIndex == itemCount)
        {
            ResetQuiz();
        }
        else
        {
            MoveToNextQuestion();
        }
    }

    protected virtual void SetInputToReadonly(bool isReadonly)
    {
        playerInput.readOnly = isReadonly;
    }

    protected virtual void ClearInput()
    {
        playerInput.text = "";

        SetInputToReadonly(false);
    }

    protected virtual void ShowAnswer()
    {
        prevSingularAns = playerInput.text;

        isAnswerShown = true;
        SetInputToReadonly(true);
    }

    protected virtual void HideAnswer()
    {
        playerInput.text = prevSingularAns;
        
        isAnswerShown = false;
        SetInputToReadonly(false);
    }

    private IEnumerator SelectFirstInputField()
    {
        yield return new WaitForEndOfFrame();
        playerInput.ActivateInputField();
        playerInput.Select();
    }
}

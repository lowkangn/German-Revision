using Newtonsoft.Json.Bson;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private static readonly string BUTTON_TEXT_SHOW_ANSWER = "Show Answer";
    private static readonly string BUTTON_TEXT_HIDE_ANSWER = "Hide Answer";

    private static readonly string MESSAGE_CORRECT = "Correct!";
    private static readonly string MESSAGE_ERROR = "Incorrect!";
    private static readonly string MESSAGE_HELP_MISSING_ANSWER = "Please input an answer.";
    private static readonly string MESSAGE_HELP_MISSING_ARTICLE = "Please include the article!";
    private static readonly string MESSAGE_HELP_NO_CAPITAL = "Nouns are capitalised!";
    private static readonly string MESSAGE_HINT = "Hint: ";

    [SerializeField] private TextMeshProUGUI gameMessage;
    [SerializeField] private TextMeshProUGUI buttonText;

    [SerializeField] private Color positiveMessageColor = Color.green;
    [SerializeField] private Color errorMessageColor = Color.red;
    [SerializeField] private Color helpMessageColor = Color.yellow;

    [Header("Event Manager")]
    [SerializeField] private UiEventManagerScriptableObject uiEventManager;

    private void OnEnable()
    {
        uiEventManager.NextQuestionEvent.AddListener(OnEnterNextQuestion);
        uiEventManager.ToggleAnswerEvent.AddListener(OnToggle);
    }

    private void OnDisable()
    {
        uiEventManager.NextQuestionEvent.RemoveListener(OnEnterNextQuestion);
        uiEventManager.ToggleAnswerEvent.AddListener(OnToggle);
    }

    public void ClearAllMessages()
    {
        gameMessage.text = "";
    }

    public void ShowCorrectMessage()
    {
        SetMessageColor(positiveMessageColor);
        gameMessage.text = MESSAGE_CORRECT;
    }

    public void ShowWrongAnswerMessage()
    {
        SetMessageColor(errorMessageColor);
        gameMessage.color = errorMessageColor;
        gameMessage.text = MESSAGE_ERROR;
    }

    public void ShowMissingAnswerMessage()
    {
        SetMessageColor(helpMessageColor);
        gameMessage.text = MESSAGE_HELP_MISSING_ANSWER;
    }

    public void ShowMissingArticleMessage()
    {
        SetMessageColor(helpMessageColor);
        gameMessage.text = MESSAGE_HELP_MISSING_ARTICLE;
    }

    public void ShowUncapitalisedNounMessage()
    {
        SetMessageColor(helpMessageColor);
        gameMessage.text = MESSAGE_HELP_NO_CAPITAL;
    }

    public void SetHint(string hint)
    {
        SetMessageColor(helpMessageColor);
        gameMessage.text = MESSAGE_HINT + hint;
    }

    private void SetMessageColor(Color color)
    {
        gameMessage.color = color;
    }

    private void OnEnterNextQuestion(bool ignored)
    {
        ClearAllMessages();
        buttonText.text = BUTTON_TEXT_SHOW_ANSWER;
    }

    private void OnToggle(bool isToggledOn)
    {
        if (isToggledOn)
        {
            buttonText.text = BUTTON_TEXT_HIDE_ANSWER;
        }
        else
        {
            buttonText.text = BUTTON_TEXT_SHOW_ANSWER;
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "UiEventManager", menuName = "ScriptableObjects/UiEventManagerScriptableObject")]
public class UiEventManagerScriptableObject : ScriptableObject
{
    private UnityEvent<bool> correctAnswerEvent;
    private UnityEvent<bool> nextQuestionEvent;
    private UnityEvent<bool> toggleAnswerEvent;

    public UnityEvent<bool> CorrectAnswerEvent => correctAnswerEvent;
    public UnityEvent<bool> NextQuestionEvent => nextQuestionEvent;
    public UnityEvent<bool> ToggleAnswerEvent => toggleAnswerEvent;

    public void OnEnable()
    {
        correctAnswerEvent = new UnityEvent<bool>();
        nextQuestionEvent = new UnityEvent<bool>();
        toggleAnswerEvent = new UnityEvent<bool>();
    }

    public void OnCorrectAnswer(bool isCurrentQnsLast)
    {
        correctAnswerEvent.Invoke(isCurrentQnsLast);
    }

    public void OnNextQuestion(bool isNextQnsLast)
    {
        nextQuestionEvent.Invoke(isNextQnsLast);
    }

    public void OnHintToggled(bool isToggledOn)
    {
        toggleAnswerEvent.Invoke(isToggledOn);
    }
}

public class ShowOnLastCorrectAnswer : HideableElement
{
    private void OnEnable()
    {
        uiEventManager.CorrectAnswerEvent.AddListener(ConditionalShow);
        uiEventManager.NextQuestionEvent.AddListener(AlwaysHide);
    }

    private void OnDisable()
    {
        uiEventManager.CorrectAnswerEvent.RemoveListener(ConditionalShow);
        uiEventManager.NextQuestionEvent.RemoveListener(AlwaysHide);
    }
}

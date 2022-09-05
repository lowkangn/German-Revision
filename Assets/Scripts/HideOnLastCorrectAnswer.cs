public class HideOnLastCorrectAnswer : HideableElement
{
    private void OnEnable()
    {
        uiEventManager.CorrectAnswerEvent.AddListener(ConditionalHide);
        uiEventManager.NextQuestionEvent.AddListener(AlwaysHide);
    }

    private void OnDisable()
    {
        uiEventManager.CorrectAnswerEvent.RemoveListener(ConditionalHide);
        uiEventManager.NextQuestionEvent.RemoveListener(AlwaysHide);
    }
}

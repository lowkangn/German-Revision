public class HideOnLastQuestion : HideableElement
{
    private void OnEnable()
    {
        uiEventManager.CorrectAnswerEvent.AddListener(AlwaysHide);
        uiEventManager.NextQuestionEvent.AddListener(ConditionalHide);
    }

    private void OnDisable()
    {
        uiEventManager.CorrectAnswerEvent.RemoveListener(AlwaysHide);
        uiEventManager.NextQuestionEvent.RemoveListener(ConditionalHide);
    }
}

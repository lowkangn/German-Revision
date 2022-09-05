public class HideOnCorrectAnswer : HideableElement
{
    private void OnEnable()
    {   
        uiEventManager.CorrectAnswerEvent.AddListener(AlwaysHide);
        uiEventManager.NextQuestionEvent.AddListener(AlwaysShow);
    }

    private void OnDisable()
    {
        uiEventManager.CorrectAnswerEvent.RemoveListener(AlwaysHide);
        uiEventManager.NextQuestionEvent.RemoveListener(AlwaysShow);
    }
}

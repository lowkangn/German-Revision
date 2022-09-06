public class HideOnToggle : HideableElement
{
    private void OnEnable()
    {
        uiEventManager.ToggleAnswerEvent.AddListener(ConditionalHide);
    }

    private void OnDisable()
    {
        uiEventManager.ToggleAnswerEvent.RemoveListener(ConditionalHide);
    }
}

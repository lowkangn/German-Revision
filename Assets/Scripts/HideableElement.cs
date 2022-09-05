using System.Collections.Generic;
using UnityEngine;

public class HideableElement : MonoBehaviour
{
    [SerializeField] protected UiEventManagerScriptableObject uiEventManager;
    [SerializeField] protected List<GameObject> elements;

    private void SetElementsActiveState(bool isActive)
    {
        foreach (GameObject element in elements)
        {
            element.SetActive(isActive);
        }
    }

    private void HideAll()
    {
        SetElementsActiveState(false);
    }

    private void ShowAll()
    {
        SetElementsActiveState(true);
    }

    protected void AlwaysHide(bool ignored)
    {
        HideAll();
    }

    protected void AlwaysShow(bool ignored)
    {
        ShowAll();
    }

    protected void ConditionalHide(bool isConditionFulfilled)
    {
        if (isConditionFulfilled)
        {
            HideAll();
        }
        else
        {
            ShowAll();
        }
    }

    protected void ConditionalShow(bool isConditionFulfilled)
    {
        if (isConditionFulfilled)
        {
            ShowAll();
        }
        else
        {
            HideAll();
        }
    }
}

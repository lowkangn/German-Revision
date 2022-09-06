using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct Item
{
    public Sprite image;
    public string singularForm;
    public string secondarySingularForm;
    public string pluralForm;
    public string secondaryPluralForm;

    public bool CheckAnswer(string singular, string plural)
    {
        bool singularMatches = singular.Equals(singularForm) || singular.Equals(secondarySingularForm);
        bool hasPluralForm = !pluralForm.Equals("");
        bool pluralMatches;

        if (hasPluralForm)
        {
            pluralMatches = plural.Equals(pluralForm) 
                || (!secondaryPluralForm.Equals("") && plural.Equals(secondaryPluralForm));
        }
        else
        {
            pluralMatches = plural.Equals("");
        }

        return singularMatches && pluralMatches;
    }
}

[CreateAssetMenu(fileName = "ItemList", menuName = "ScriptableObjects/ItemListScriptableObject")]
public class ItemListScriptableObject : AnswerListScriptableObject<Item>
{

}

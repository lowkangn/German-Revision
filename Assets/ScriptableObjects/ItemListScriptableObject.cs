using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Item
{
    public Sprite image;
    public string singularForm;
    public string secondarySingularForm;
    public string pluralForm;

    public bool CheckAnswer(string singular, string plural)
    {
        return (singular.Equals(singularForm)
            || (!secondarySingularForm.Equals("") && singular.Equals(secondarySingularForm)))
            && plural.Equals(pluralForm);
    }
}

[CreateAssetMenu(fileName = "ItemList", menuName = "ScriptableObjects/ItemListScriptableObject")]
public class ItemListScriptableObject : AnswerListScriptableObject<Item>
{

}

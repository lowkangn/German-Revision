using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct WordPair
{
    public string english;
    public string german;

    public bool CheckAnswer(string answer, bool isEnglish)
    {
        return isEnglish ? answer.Equals(english.ToString()) : answer.Equals(german.ToString());
    }
}

[CreateAssetMenu(fileName = "WordList", menuName = "ScriptableObjects/WordListScriptableObject")]
public class WordListScriptableObject : AnswerListScriptableObject<WordPair>
{
    
}

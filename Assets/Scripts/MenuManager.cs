using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void SelectWordGame(bool isAnswerInEnglish)
    {
        PersistentData.IsAnswerInEnglish = isAnswerInEnglish;
    }

    public void SelectChapter(int chapter)
    {
        PersistentData.selectedChapter = chapter;
    }
}

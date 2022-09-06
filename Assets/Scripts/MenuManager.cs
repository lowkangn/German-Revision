using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject chapterMenu;

    public void SelectWordGame(bool isAnswerInEnglish)
    {
        PersistentData.IsAnswerInEnglish = isAnswerInEnglish;
    }

    public void ReturnToChapterMenu()
    {
        chapterMenu.SetActive(true);
        gameMenu.SetActive(false);
    }

    public void SelectChapter(int chapter)
    {
        gameMenu.SetActive(true);
        chapterMenu.SetActive(false);

        PersistentData.selectedChapter = chapter;
    }
}

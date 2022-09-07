using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    private static readonly string SCENE_NAME_CHAPTER_MENU = "ChapterMenu";
    private static readonly string SCENE_NAME_GAME_MENU = "GameMenu";
    private static readonly string SCENE_NAME_NOUN_GAME = "NounsGame";
    private static readonly string SCENE_NAME_WORD_GAME = "WordGame";

    public void SwitchToChapterMenu()
    {
        SceneManager.LoadScene(SCENE_NAME_CHAPTER_MENU);
    }

    public void SwitchToGameMenu()
    {
        SceneManager.LoadScene(SCENE_NAME_GAME_MENU);
    }

    public void SwitchToWordGame()
    {
        SceneManager.LoadScene(SCENE_NAME_WORD_GAME);
    }

    public void SwitchToNounGame()
    {
        SceneManager.LoadScene(SCENE_NAME_NOUN_GAME);
    }
}

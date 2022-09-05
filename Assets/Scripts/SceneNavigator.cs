using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    private static readonly string SCENE_NAME_MENU = "Menu";
    private static readonly string SCENE_NAME_NOUN_GAME = "NounsGame";
    private static readonly string SCENE_NAME_WORD_GAME = "WordGame";

    public void SwitchToMainMenu()
    {
        SceneManager.LoadScene(SCENE_NAME_MENU);
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

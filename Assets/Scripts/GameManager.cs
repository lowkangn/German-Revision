using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void IsAnswerInEnglish(bool isAnswerInEnglish)
    {
        PersistentData.IsAnswerInEnglish = isAnswerInEnglish;
    }
}

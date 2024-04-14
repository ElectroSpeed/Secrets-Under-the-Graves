using UnityEngine.SceneManagement;
using UnityEngine;

public class GetEnds : MonoBehaviour
{
    public static GetEnds Instance;

    public void Awake()
    {
        Instance = this;
    }

    public void SetDogDeath()
    {
        SaveManager.Instance._dogDeath = true;
        SaveManager.Instance.SaveData();
        SceneManager.LoadScene("MainMenu");
    }

    public void SetDogFriend()
    {
        SaveManager.Instance._dogFriend = true;
        SaveManager.Instance.SaveData();
        SceneManager.LoadScene("MainMenu");
    }

    public void SetDraculaDeath()
    {
        SaveManager.Instance._draculaDeath = true;
        SaveManager.Instance.SaveData();
        SceneManager.LoadScene("MainMenu");
    }

    public void SetDraculaVictory()
    {
        SaveManager.Instance._draculaVictory = true;
        SaveManager.Instance.SaveData();
        SceneManager.LoadScene("MainMenu");
    }

    public void SetTreasure()
    {
        SaveManager.Instance._treasure = true;
        SaveManager.Instance.SaveData();
        SceneManager.LoadScene("MainMenu");
    }

    public void SetCimetery()
    {
        SaveManager.Instance._cimetery = true;
        SaveManager.Instance.SaveData();
        SceneManager.LoadScene("MainMenu");
    }
}
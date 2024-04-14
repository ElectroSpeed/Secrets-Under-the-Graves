using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public bool _dogDeath = false;
    public bool _dogFriend = false;
    public bool _draculaDeath = false;
    public bool _draculaVictory = false;
    public bool _treasure = false;
    public bool _cimetery = false;

    private const string DogDeathKey = "DogDeath";
    private const string DogFriendKey = "DogFriend";
    private const string DraculaDeathKey = "DraculaDeath";
    private const string DraculaVictoryKey = "DraculaVictory";
    private const string TreasureKey = "Treasure";
    private const string CimeteryKey = "Cimetery";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt(DogDeathKey, _dogDeath ? 1 : 0);
        PlayerPrefs.SetInt(DogFriendKey, _dogFriend ? 1 : 0);
        PlayerPrefs.SetInt(DraculaDeathKey, _draculaDeath ? 1 : 0);
        PlayerPrefs.SetInt(DraculaVictoryKey, _draculaVictory ? 1 : 0);
        PlayerPrefs.SetInt(TreasureKey, _treasure ? 1 : 0);
        PlayerPrefs.SetInt(CimeteryKey, _cimetery ? 1 : 0);
        PlayerPrefs.Save();
    }
}

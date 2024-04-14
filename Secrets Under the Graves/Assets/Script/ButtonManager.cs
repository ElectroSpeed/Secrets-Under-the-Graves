using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu, _endMenu;
    private bool _pauseActive;
    private bool _endActive;
    private bool _successActive;

    [SerializeField] private Image _imageDogDeath;
    [SerializeField] private Image _imageDogFriend;
    [SerializeField] private Image _imageDraculaDeath;
    [SerializeField] private Image _imageDraculaVictory;
    [SerializeField] private Image _imageTreasure;
    [SerializeField] private Image _imageCimetery;

    public static ButtonManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        _imageDogDeath.gameObject.SetActive(false);
        _imageDogFriend.gameObject.SetActive(false);
        _imageDraculaDeath.gameObject.SetActive(false);
        _imageDraculaVictory.gameObject.SetActive(false);
        _imageTreasure.gameObject.SetActive(false);
        _imageCimetery.gameObject.SetActive(false);


        Screen.SetResolution(1920, 1080, true);
        Time.timeScale = 1.0f;

        if (SaveManager.Instance._dogDeath)
        {
            _imageDogDeath.gameObject.SetActive(true);
        }
        if (SaveManager.Instance._dogFriend)
        {
            _imageDogFriend.gameObject.SetActive(true);
        }
        if (SaveManager.Instance._draculaDeath)
        {
            _imageDraculaDeath.gameObject.SetActive(true);
        }
        if (SaveManager.Instance._draculaVictory)
        {
            _imageDraculaVictory.gameObject.SetActive(true);
        }
        if (SaveManager.Instance._treasure)
        {
            _imageTreasure.gameObject.SetActive(true);
        }
        if (SaveManager.Instance._cimetery)
        {
            _imageCimetery.gameObject.SetActive(true);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PauseMenu(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (!_pauseActive)
            {
                GameObject.Find("MenuManager").transform.Find("PauseMenu").gameObject.SetActive(true);
                _pauseActive = true;
                Time.timeScale = 0.0f;
            }
            else
            {
                GameObject.Find("MenuManager").transform.Find("PauseMenu").gameObject.SetActive(false);
                _pauseActive = false;
                Time.timeScale = 1.0f;
            }
        }
    }

    public void PauseMenuButton()
    {
        if (!_pauseActive)
        {
            GameObject.Find("MenuManager").transform.Find("PauseMenu").gameObject.SetActive(true);
            _pauseActive = true;
            Time.timeScale = 0.0f;
        }
        else
        {
            GameObject.Find("MenuManager").transform.Find("PauseMenu").gameObject.SetActive(false);
            _pauseActive = false;
            Time.timeScale = 1.0f;
        }
    }
    public void EndMenu()
    {
        if (!_endActive)
        {
            GameObject.Find("MenuManager").transform.Find("EndMenu").gameObject.SetActive(true);
            _endActive = true;
            Time.timeScale = 0.0f;
        }
        else
        {
            GameObject.Find("MenuManager").transform.Find("EndMenu").gameObject.SetActive(false);
            _endActive = false;
            Time.timeScale = 0.0f;
        }
    }

    public void SuccessMenu()
    {
        if (!_successActive)
        {
            GameObject.Find("MenuManager").transform.Find("Global").gameObject.SetActive(false);
            GameObject.Find("MenuManager").transform.Find("Success").gameObject.SetActive(true);
            _successActive = true;
        }
        else
        {
            GameObject.Find("MenuManager").transform.Find("Global").gameObject.SetActive(true);
            GameObject.Find("MenuManager").transform.Find("Success").gameObject.SetActive(false);
            _successActive = false;
        }
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

}

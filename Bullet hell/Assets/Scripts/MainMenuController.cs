using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button StartGame;
    public Button CreditButton;

    public Button back;

    public GameObject CreditPage;
    public GameObject MainMenuPage;
    public string NextScene;

    void Start()
    {
        StartGame.onClick.AddListener(StartTheGame);
        CreditButton.onClick.AddListener(OpenCredits);
        back.onClick.AddListener(GoBack);

    }


    void OpenCredits()
    {
        MainMenuPage.SetActive(false);
        CreditPage.SetActive(true);
    }

    void GoBack()
    {
        MainMenuPage.SetActive(true);
        CreditPage.SetActive(false);
    }


    void StartTheGame()
    {
        SceneManager.LoadScene(NextScene);
    }
}
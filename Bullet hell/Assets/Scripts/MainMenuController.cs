using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{


    public Button SceneSwitcher;
    public AudioSource ButtonClickSound;
    public string NextScene;

    void Start()
    {

        SceneSwitcher.onClick.AddListener(StartTheGame);

    }



    void StartTheGame()
    {
        ButtonClickSound.Play();
        SceneManager.LoadScene(NextScene);
    }
}
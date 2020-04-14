using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Text SceneName;
    public Button NextScene;
    public Button PreviousScene;
    private int m_SceneIndex;

    public void SetNextScene()
    {
        m_SceneIndex++;
        SceneManager.LoadScene(m_SceneIndex);
    }

    public void SetPreviousScene()
    {
        m_SceneIndex--;
        SceneManager.LoadScene(m_SceneIndex);
    }

    private void Start()
    {
        m_SceneIndex = SceneManager.GetActiveScene().buildIndex;
        PreviousScene.interactable = m_SceneIndex != 0;
        NextScene.interactable = m_SceneIndex != SceneManager.sceneCountInBuildSettings - 1;
        SceneName.text = SceneManager.GetActiveScene().name;
    }
}

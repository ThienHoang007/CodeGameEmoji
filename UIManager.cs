using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;
    public static UIManager Instance;

    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Starts;
    [SerializeField] private GameObject Instan;

    private void Awake()
    {
        if(instance == null) { instance = this; }
        else if(this.GetInstanceID() != instance.GetInstanceID()) { Destroy(this); }
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("art") == 1)
        {
            Starts.SetActive(false);
            OnStart();
            Time.timeScale = 1f;
        }
        else
        {
            Starts.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void OnMenu()
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OffMenu()
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void relay()
    {
        SceneManager.LoadScene("scene", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
    public void OnStart()
    {
        Starts.SetActive(false);
        StartCoroutine(Instan.GetComponent<InstancEnemy>().InstanAfterTime(3f));
        PlayerPrefs.SetInt("art", 1);
        Time.timeScale = 1f;
    }
}

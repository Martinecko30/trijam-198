using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Warmth")]
    public float Warmth = 100;
    [SerializeField] public float loseSpeed = 10f;
    [SerializeField] private Slider warmthMeter;

    [Header("Time")]
    [HideInInspector] private int time = 0;
    [SerializeField] private int minutes = 3;
    [SerializeField] private TMP_Text timeText;

    [Header("Cursors")]
    public Texture2D defaultCursor;
    // Keep separated so unity won't break with headers
    public Texture2D fireCursor, stoneCursor, woodCursor;

    [Header("Holding")]
    public bool Stone = false;
    public bool Wood = false;

    [Header("Death")]
    [SerializeField] private GameObject deathScreen;
    [HideInInspector] public bool dead = false;

    [Header("Win")]
    [SerializeField] private GameObject winScreen;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        deathScreen.SetActive(false);
        winScreen.SetActive(false);
        DontDestroyOnLoad(gameObject);

        timeText.text = time + "am";
        StartCoroutine(TimeMovement());
        ChangeCursor(defaultCursor);
    }

    private void Update()
    {
        if (time > 6)
            Win();
        Warmth -= 2.5f * (Time.deltaTime * loseSpeed);
        Warmth = Mathf.Clamp(Warmth, 0, 100);
        warmthMeter.value = Warmth;

        if(Warmth <= 0) {
            Death();
        }
    }

    private IEnumerator TimeMovement()
    {
        yield return new WaitForSeconds(minutes * 60f);
        time += 1;
        timeText.text = time + "am";
    }

    public void ChangeCursor(Texture2D cursor)
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    public void Win()
    {
        winScreen.SetActive(true);
    }

    public void Death()
    {
        dead = true;
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
    }

    public void Restart()
    {
        deathScreen.SetActive(false);
        Time.timeScale = 1f;
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
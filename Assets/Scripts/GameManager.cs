using System.Collections;
using TMPro;
using UnityEngine;
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
    public Texture2D fireCursor, stoneCursor;

    public static GameManager Instance;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        timeText.text = time + "am";
        StartCoroutine(TimeMovement());
        ChangeCursor(defaultCursor);
    }

    private void Update()
    {
        Warmth -= 2.5f * (Time.deltaTime * loseSpeed);
        Warmth = Mathf.Clamp(Warmth, 0, 100);
        warmthMeter.value = Warmth;
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
}
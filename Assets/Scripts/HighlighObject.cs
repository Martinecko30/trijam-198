using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HighlighObject : MonoBehaviour
{
    [Header("SpriteRenderer + Shader")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Shader shader;
    [SerializeField] private string shaderName = "HighlightShader";

    private void Start()
    {
        shader = Shader.Find(shaderName);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        GameManager.Instance.ChangeCursor(GameManager.Instance.fireCursor);
        spriteRenderer.material.shader = shader;
    }

    private void OnMouseExit()
    {
        GameManager.Instance.ChangeCursor(GameManager.Instance.defaultCursor);
        spriteRenderer.material.shader = null;
    }
}

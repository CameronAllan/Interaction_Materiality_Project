using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEffect : MonoBehaviour
{
    RectTransform rect;

    public bool isActive;
    public bool isMoving;

    public Image effectImage;
    public Vector2 startPos;
    public Vector2 endPos;

    public float effectSpeed;
    public float effectLength = 0.3f;

    Vector2 velocity;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isActive && rect.anchoredPosition != endPos && !isMoving)
        {
            StartCoroutine(TransitionElement(endPos));
        }
        else if (!isActive && !isMoving && rect.anchoredPosition != startPos)
        {
            StartCoroutine(TransitionElement(startPos));
        }
    }

    private IEnumerator TransitionElement(Vector2 endPos)
    {
        isMoving = true;
        float timer = effectLength;
        while (rect.anchoredPosition != endPos && timer > 0)
        {
            rect.anchoredPosition = Vector2.SmoothDamp(rect.anchoredPosition, endPos, ref velocity, effectLength);
            timer -= Time.deltaTime;
            yield return 0;
        }
        isMoving = false;
    }

    private void OnEnable()
    {
        rect.anchoredPosition = startPos;
    }

    private void OnDisable()
    {
        isActive = false;
        isMoving = false;

    }
}


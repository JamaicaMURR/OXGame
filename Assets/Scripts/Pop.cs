using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pop : MonoBehaviour
{
    Text textField;
    SpriteRenderer spriteRenderer;

    public IndependentClocks indieClocks;

    public float evaporatingSpeed;
    public float fadingTime;

    public bool evaporateAtStart = false;

    RawProvider GetDeltaTime;
    RawConsumer FadeText;
    RawConsumer FadeSprite;

    private void Awake()
    {
        if(indieClocks != null)
            GetDeltaTime = delegate () { return indieClocks.DeltaTime; };
        else
            GetDeltaTime = delegate () { return Time.deltaTime; };

        textField = GetComponent<Text>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(textField != null)
            FadeText = delegate (float expiredTime)
            {
                textField.color = new Color(textField.color.r, textField.color.g, textField.color.b, 1 - (expiredTime / fadingTime));
            };
        else
            FadeText = delegate (float t) { };

        if(spriteRenderer != null)
            FadeSprite = delegate (float expiredTime)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1 - (expiredTime / fadingTime));
            };
        else
            FadeSprite = delegate (float t) { };
    }

    private void Start()
    {
        if(evaporateAtStart)
            BeginEvaporating();
    }

    public void BeginEvaporating()
    {
        StartCoroutine(Evaporate());
    }

    IEnumerator Evaporate()
    {
        float expiredTime = 0;

        while(expiredTime < fadingTime)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + evaporatingSpeed * GetDeltaTime(), transform.position.z);

            FadeText(expiredTime);
            FadeSprite(expiredTime);

            expiredTime += GetDeltaTime();

            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
        yield break;
    }
}

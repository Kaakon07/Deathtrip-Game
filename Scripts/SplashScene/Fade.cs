using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Fade : MonoBehaviour
{
    [SerializeField]SpriteRenderer spriteRenderer;
    [SerializeField] Sprite secondSprite;
    [SerializeField] AudioClip mainMenuTheme;
    [SerializeField] AudioSource aSource;
    private IEnumerator FadeIn()
    {
        float alphaVal = spriteRenderer.color.a;
        Color tmp = spriteRenderer.color;

        while (spriteRenderer.color.a > 0)
        {
            alphaVal -= 0.01f;
            tmp.a = alphaVal;
            spriteRenderer.color = tmp;

            yield return new WaitForSeconds(0.02f); // update interval
        }
    }

    private IEnumerator FadeOut()
    {
        float alphaVal = spriteRenderer.color.a;
        Color tmp = spriteRenderer.color;

        while (spriteRenderer.color.a < 1)
        {
            alphaVal += 0.01f;
            tmp.a = alphaVal;
            spriteRenderer.color = tmp;

            yield return new WaitForSeconds(0.02f); // update interval
        }
    }

    private IEnumerator FadeInOut()
    {
        yield return StartCoroutine(FadeOut());
        yield return StartCoroutine(FadeIn());
        yield return spriteRenderer.sprite = secondSprite;
        yield return StartCoroutine(FadeOut());
        yield return StartCoroutine(FadeIn());
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void Start()
    {

        StartCoroutine(FadeInOut());
        Invoke("LoadMenu",mainMenuTheme.length);
        
        
        
    }
    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu();
        }
    }
}

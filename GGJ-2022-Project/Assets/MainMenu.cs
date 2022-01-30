using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button PlayButton;
    public Button CreditsButton;
    public Button QuitButton;

    public CanvasGroup CreditsPanel;

    private bool _creditsOpen;

    private void Start()
    {
        PlayButton.onClick.AddListener(Play);
        QuitButton.onClick.AddListener(Quit);
        CreditsButton.onClick.AddListener(ToggleCredits);
        CreditsPanel.alpha = 0;
    }

    private void ToggleCredits()
    {
        CreditsPanel.DOKill();
        CreditsPanel.DOFade(_creditsOpen ? 0.0f : 1.0f, 0.2f);
        _creditsOpen = !_creditsOpen;
    }

    private void Quit()
    {
        CoroutineService.Instance.StartCoroutine(Coro());

        IEnumerator Coro()
        {
            ScreenFader.Instance.FadeOut();
            yield return ScreenFader.Instance.Fade;
            Application.Quit();
        }
    }

    private void Play()
    {
        CoroutineService.Instance.StartCoroutine(Coro());

        IEnumerator Coro()
        {
            ScreenFader.Instance.FadeOut();
            yield return ScreenFader.Instance.Fade;
            SceneManager.LoadScene("Greybox");
            yield return new WaitForSeconds(2f);
            ScreenFader.Instance.FadeIn();
        }
    }
}

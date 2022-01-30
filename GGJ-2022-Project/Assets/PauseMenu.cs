using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : Singleton<PauseMenu>
{
    public CanvasGroup Group;
    public Button SaveAndQuit;
    public Button Resume;
    private bool _visible;

    private void Start()
    {
        Group.alpha = 0;
        SaveAndQuit.onClick.AddListener(Quit);
        Resume.onClick.AddListener(Hide);
    }

    public void Show()
    {
        Cursor.lockState = CursorLockMode.Confined;
        
        Group.DOKill();
        Group.DOFade(1.0f, 0.2f);
        _visible = true;
    }

    public void Hide()
    {
        Cursor.lockState = CursorLockMode.Locked;
        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1f, 0.2f).SetUpdate(true);
        
        Group.DOKill();
        Group.DOFade(0.0f, 0.2f);
        _visible = false;
    }

    private void Quit()
    {
        CoroutineService.Instance.StartCoroutine(Coro());

        IEnumerator Coro()
        {
            ScreenFader.Instance.FadeOut();
            SaveManager.Instance.Save();
            yield return ScreenFader.Instance.Fade;
            SceneManager.LoadScene("Menu");
            yield return new WaitForSeconds(1f);
            ScreenFader.Instance.FadeIn();
        }
    }

    public void Toggle()
    {
        if(_visible)
            Hide();
        else
            Show();
    }
}

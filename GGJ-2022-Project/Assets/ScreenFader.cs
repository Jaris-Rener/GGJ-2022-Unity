using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : Singleton<ScreenFader>
{
    public Image Image;
    public YieldInstruction Fade;
    
    public void FadeOut()
    {
        Image.DOKill();
        Fade = Image.DOFade(1.0f, 1.0f).WaitForCompletion();
    }
    
    public void FadeIn()
    {
        Image.DOKill();
        Fade = Image.DOFade(0.0f, 1.0f).WaitForCompletion();
    }
}

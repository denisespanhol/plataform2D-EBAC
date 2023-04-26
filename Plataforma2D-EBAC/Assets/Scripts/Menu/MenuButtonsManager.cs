using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttons;

    [Header("Animation")]
    [SerializeField] private float duration = .2f;
    [SerializeField] private float delay = .2f;
    [SerializeField] private Ease ease = Ease.OutBack;

    private void OnEnable()
    {
        HideAllButtons();
        ShowButtons();
    }

    private void HideAllButtons()
    {
        foreach(var b in buttons)
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }

    private void ShowButtons()
    {
        int multiplier = 0;

        foreach(var b in buttons)
        {
            multiplier += 1;
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(multiplier * delay).SetEase(ease);
        }
    }
}

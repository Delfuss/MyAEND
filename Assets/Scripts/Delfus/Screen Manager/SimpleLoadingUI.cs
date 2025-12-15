using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SimpleLoadingUI : MonoBehaviour, IScreenTransition
{
    [SerializeField] GameObject loadingPanel;
    [SerializeField] Slider progressBar;

    public void ShowLoading() => loadingPanel.SetActive(true);
    public void HideLoading() => loadingPanel.SetActive(false);
    public void SetProgress(float progress)
    {
        if (progressBar != null)
            progressBar.value = progress;
    }
}

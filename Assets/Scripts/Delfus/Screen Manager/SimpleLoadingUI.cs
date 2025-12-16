using UnityEngine;

public class SimpleLoadingUI : MonoBehaviour
{
    [SerializeField] private GameObject loadingPanel;

    private void Awake()
    {
        ShowLoading();
    }

    public void ShowLoading() => loadingPanel.SetActive(true);
    public void HideLoading() => loadingPanel.SetActive(false);
}

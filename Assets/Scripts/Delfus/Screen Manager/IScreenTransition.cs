using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScreenTransition
{
    void ShowLoading();
    void HideLoading();
    void SetProgress(float progress);
}

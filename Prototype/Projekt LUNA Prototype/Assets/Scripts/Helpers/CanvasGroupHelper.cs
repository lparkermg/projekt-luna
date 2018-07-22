using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.U2D;
using UnityEngine;

public static class CanvasGroupHelper {

    public static void Show(this CanvasGroup c)
    {
        c.alpha = 1.0f;
        c.interactable = true;
        c.blocksRaycasts = true;
    }

    public static void Hide(this CanvasGroup c)
    {
        c.alpha = 0.0f;
        c.interactable = false;
        c.blocksRaycasts = false;
    }
}

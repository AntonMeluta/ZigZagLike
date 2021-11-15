using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TapImageControl : MonoBehaviour
{
    private Sequence sequence;

    public float duration = 0.5f;

    private void Awake()
    {
        sequence = DOTween.Sequence();
        sequence.SetLoops(-1, LoopType.Yoyo);
    }

    private void Start()
    {
        sequence.Append(transform.DOBlendableScaleBy(Vector3.one / 2, duration));        
    }
}

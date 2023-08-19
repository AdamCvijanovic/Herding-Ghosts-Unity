using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSorter : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float yValue = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        yValue = transform.position.y;

    }

    private void LateUpdate()
    {
            spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
    }
}

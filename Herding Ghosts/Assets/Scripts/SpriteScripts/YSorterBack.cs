using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSorterBack : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float modifier = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -500 + modifier);

    }
}

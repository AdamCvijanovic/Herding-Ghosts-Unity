using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSorter : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float modifier = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
      

    }

    private void LateUpdate()
    {
            spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -100 + modifier);
    }
}

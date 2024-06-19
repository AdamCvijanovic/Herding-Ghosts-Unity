using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiquidMelt : MonoBehaviour
{
    public GameObject[] liquids;

    public GameObject finalLiquid;

    private bool melt = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (melt)
        {
            MeltLiquid();
        }
    }

   public void MeltLiquid()
    {

        foreach (GameObject obj in liquids)
        {
            var img = obj.GetComponent<Image>();
            Color currentColor = img.color;
            currentColor.a -= 0.05f;
            img.color = currentColor;
        }


        var imgFinal = finalLiquid.GetComponent<Image>();
        Color currentColor2 = imgFinal.color;
        currentColor2.a += 0.05f;

        if (currentColor2.a >= 0.95)
            melt = false;

        imgFinal.color = currentColor2;

    }

    public void StartMelting()
    {
        melt = true;
        finalLiquid.SetActive(true);
    }

    private IEnumerator Boil()
    {


        yield return null;
    }
}


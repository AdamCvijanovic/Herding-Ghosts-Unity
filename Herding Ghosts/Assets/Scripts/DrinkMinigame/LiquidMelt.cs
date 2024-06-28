using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiquidMelt : MonoBehaviour
{
    public GameObject[] liquids;

    public GameObject finalLiquid;

    public GameObject canvas;

    public GameObject congrats;

    public GameObject UI;

    public GrimoireUI grimoire;

    public OpenMinigame game;


    private bool melt = false;


    //TEMP ONLY FOR SHOW
    public GameObject bobatea;
    public Transform table;

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
        {
            melt = false;
            StartCoroutine(Congrats());
        }

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

    private IEnumerator Congrats()
    {
        yield return new WaitForSeconds(1f);
        congrats.SetActive(true);
        yield return new WaitForSeconds(2f);
        game.DisableMinigame();
        UI.SetActive(true);
        grimoire.Deactivate();

        Instantiate(bobatea, new Vector3(table.position.x + 2, table.position.y, 1), table.rotation);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasActiveScript : MonoBehaviour, Activate, DeActivate
{
    public enum type
    {
        Default, Animation, List
    }
    public type _type;

    [SerializeField] private float playtime; // how long to play for default type
    [SerializeField] private GameObject canvasUI;
    [SerializeField] private GameObject[] canvasUIArray;


    public void Activate()
    {
        activeCanvas();
    }

    public void DeActivate()
    {
        activeCanvas();
    }

    private void activeCanvas()
    {
        switch (_type)
        {
            case type.Default:
                StartCoroutine(canvasActive());
                break;
            case type.Animation:
                Animator anim = canvasUI.GetComponent<Animator>();
                anim.enabled = !anim.enabled;
                break;
            case type.List:
                StartCoroutine(canvasListActive());
                break;
        }
    }

    IEnumerator canvasActive()
    {
        canvasUI.SetActive(true);
        yield return new WaitForSeconds(playtime);
        canvasUI.SetActive(false);
    }

    IEnumerator canvasListActive()
    {
        for (int i = 0; i < canvasUIArray.Length; i++)
        {
            if(i != 0)
                canvasUIArray[i-1].SetActive(false);
            yield return new WaitForSeconds(playtime);
            canvasUIArray[i].SetActive(true);
            yield return new WaitForSeconds(playtime);
        }
    }
}

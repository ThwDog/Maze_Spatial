using System.Collections;
using UnityEngine;

public class TorchScript : MonoBehaviour, Activate, DeActivate
{
    [SerializeField] Light _light;

    float maxLightIntensity = 3;

    bool isPlay = false;

    public void Activate()
    {
        if(_light.intensity <= 1 & !isPlay)
            turnOn();
        // Debug.Log("Light Active");
    }

    public void DeActivate()
    {
        if(_light.intensity > 0 )
            turnOff();
        // Debug.Log("Light DeActive");
    }

    private void turnOff()
    {
        StartCoroutine(lightTurnOff());
        isPlay = false;
    }

    private void turnOn()
    {
        StartCoroutine(lightTurnOn());
        isPlay = true;
    }

    IEnumerator lightTurnOff()
    {
        // Debug.Log("Off");
        while (_light.intensity > 0.25)
        {
            _light.intensity -= 0.01f;

            yield return null;
        }
    }

    IEnumerator lightTurnOn()
    {
        // Debug.Log("on");
        while (_light.intensity < maxLightIntensity)
        {
            _light.intensity += 0.01f;

            yield return null;
        }
    }
}

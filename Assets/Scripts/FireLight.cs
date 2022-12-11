using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireLight : MonoBehaviour
{
    [SerializeField] private Light2D fireLight;
    [SerializeField] private float intensityChanger = 0.08f;
    private bool canChange = true, adding;

    private void Update()
    {
        if (canChange)
            StartCoroutine(ChangeLightIntensityCoroutine());
    }

    private IEnumerator ChangeLightIntensityCoroutine()
    {
        canChange = false;
        while(fireLight.intensity >= 0.8 && fireLight.intensity <= 1)
        {
            if(adding)
                fireLight.intensity += intensityChanger;
            else
                fireLight.intensity -= intensityChanger;
            yield return new WaitForSeconds(0.2f);
        }
        adding = !adding;
        canChange = true;
    }
}

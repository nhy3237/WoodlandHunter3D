using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartParticle : MonoBehaviour
{
    
    Image particleImage;
    float curAlpha;
    float Direction;
    float changeAmount = 1f;

    // Start is called before the first frame update
    void Start()
    {
        particleImage = GetComponent<Image>();
        float randomValue = Random.Range(0f, 1f); // 0부터 1 사이의 랜덤 값 생성

        if(randomValue > 0.5)
        {
            curAlpha = 1;
            Direction = -1;
        }
        else
        {
            curAlpha = 0;
            Direction = 1;
        }

        StartCoroutine(PulseAlpha());

    }


    IEnumerator PulseAlpha()
    {

        while(true)
        {
            curAlpha += changeAmount * Direction * Time.deltaTime;
            particleImage.color = new Color(particleImage.color.r, particleImage.color.g, particleImage.color.b, curAlpha);

            if (curAlpha >= 1 && Direction == 1)
            {
                Direction = -1;
                yield return new WaitForSeconds(1f);

            }
            else if (curAlpha <= 0 && Direction == -1)
            {
                Direction = 1;
                yield return new WaitForSeconds(1f);

            }
            yield return null;

        }

    }
}

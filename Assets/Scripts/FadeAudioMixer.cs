// =============================================================================
//                            Criado por John of gamedevbeginner
// =============================================================================
//
// Fonte: https://gamedevbeginner.com/how-to-fade-audio-in-unity-i-tested-every-method-this-ones-the-best/
//
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public static class FadeAudioMixer
{

    public static IEnumerator StartFade(AudioMixer audioMixer, string exposedParam, float duration, float targetVolume, float fadeOutWait = 0f)
    {

        yield return new WaitForSeconds(fadeOutWait);

        float currentTime = 0;
        float currentVol;

        // Para fazermos o fadeOut

        // Pega o volume atual do Audiomixer
        // Variaveis out sao variaveis de saida
        // Sao modificadas dentro do escopo da funcao
        audioMixer.GetFloat(exposedParam, out currentVol);

        // currentVol =  10^(currentVol/20)
        currentVol = Mathf.Pow(10, currentVol / 20);
        
        // limita o valor destino entre 0 e 1
        float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);

        // Verifica durante a duracao, diminuindo o volume
        while (currentTime < duration)
        {
            // Soma quanto tempo passou
            currentTime += Time.deltaTime;

            // Interpola os valores currentVol e targetValue usando currentTime / duration
            // Isto eh, supondo valores 0(origem) e 10(destino) 
            // Se passarmos 0.5, como valor intermediario
            // o Lerp retorna a interpolação linear, ou seja, 5
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);

            // Por fim, atribua ao AudioMixer esse volume
            audioMixer.SetFloat(exposedParam, Mathf.Log10(newVol) * 20);

            // Retorna nulo para poder ficar neste no, e retoma-lo no proximo frame
            yield return null;
        }
        yield break;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Frase : MonoBehaviour, IDropHandler
{
    private Image slot;
    private RectTransform rect;
    public GameObject botaoFrase;

    public void Start()
    {
        slot = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            var frase = eventData.pointerDrag.GetComponent<Button>().name;

            if (frase == botaoFrase.name)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rect.anchoredPosition;
                slot.color = Color.green;
                ScoreManager.Instance.Acertou();
                botaoFrase.GetComponent<MovimentarUI>().DesabilitarBotao();
                Destroy(gameObject.GetComponent<Frase>());
            }
            else
            {
                slot.color = Color.red;
                ScoreManager.Instance.Errou();
            }
        }
    }
}

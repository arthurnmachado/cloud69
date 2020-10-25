using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Frase2 : MonoBehaviour, IDropHandler
{
    public Image slot;
    public RectTransform rect;

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

            if (frase == "Frase2")
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rect.anchoredPosition;
                slot.color = Color.green;
            }
            else
            {
                slot.color = Color.red;
            }
        }
    }
}

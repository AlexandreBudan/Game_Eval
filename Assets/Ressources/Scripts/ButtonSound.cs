using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HighlightedButton : MonoBehaviour, IPointerEnterHandler
{
    // Méthode appelée lorsque le curseur de la souris entre dans le bouton
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject.Find("BoutonSound").GetComponent<AudioSource>().Play(0);
    }
}

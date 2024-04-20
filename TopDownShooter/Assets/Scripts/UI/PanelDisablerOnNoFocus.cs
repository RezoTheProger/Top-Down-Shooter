using UnityEngine;
using UnityEngine.EventSystems;

public class PanelDisablerOnNoFocus : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool inContext;
    private void Awake()
    {
        transform.localScale= Vector2.zero;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && inContext == false)
        {
            transform.LeanScale(Vector2.zero, .3f).setEaseInBack();

        }
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        inContext = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inContext = false;
    }
}
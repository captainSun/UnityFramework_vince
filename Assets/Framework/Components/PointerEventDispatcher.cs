using UnityEngine;
using UnityEngine.EventSystems;

namespace VinceFramework
{
    public class PointerEventDispatcher : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        
        
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            // DispatchEvent(ed, EVENT_ENTER, eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
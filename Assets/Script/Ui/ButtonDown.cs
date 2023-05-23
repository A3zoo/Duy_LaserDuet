using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonDown : MonoBehaviour, IPointerUpHandler, IPointerExitHandler, IPointerDownHandler
{
    public int state;
    public void OnPointerDown(PointerEventData eventData)
    {
        GamePlayManager.Instance.GetPlayer().GetComponent<Player>()._stateRotage = state;
        GamePlayManager.Instance.GetPlayer().GetComponent<Player>()._ballA.GetComponent<Ball>().StartRotage(state);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        DOTween.Kill("RotagePlayer");
        GamePlayManager.Instance.GetPlayer().GetComponent<Player>()._stateRotage = 0;
        GamePlayManager.Instance.GetPlayer().GetComponent<Player>()._ballA.GetComponent<Ball>().FinishRotage();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      
    }
}

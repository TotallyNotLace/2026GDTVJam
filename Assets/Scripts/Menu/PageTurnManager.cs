using UnityEngine;

public class PageTurnManager : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private string pageTrigger;
    [SerializeField] private bool canTurnBack;
    [SerializeField] private string pageBackTrigger;

    public void TurnPage()
    {
        anim.SetTrigger(pageTrigger);
    }

    public void TurnPageBack()
    {
        if(!canTurnBack) return;
        
        anim.SetTrigger(pageBackTrigger);
    }
}

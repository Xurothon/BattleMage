using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Helpers.Instance.UIHelper.ActiveLevelCompletPanel();
            Helpers.Instance.CoinsCounter.SaveCoinsCount();
        }
    }
}

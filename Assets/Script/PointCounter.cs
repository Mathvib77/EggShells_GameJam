using System.Collections;
using UnityEngine;

public class PoinCounter : MonoBehaviour
{
    [SerializeField] PointsHUD pointsHUD;

    private void Start()
    {
        StartCoroutine(CounterPoint());
    }

    private IEnumerator CounterPoint()
    {
        while (true)
        {
            // Applique le multiplicateur courant défini par ZoneMults
            pointsHUD.Points += Mathf.RoundToInt(5 * ZoneMults.CurrentMultiplier);
            yield return new WaitForSeconds(1);
        }
    }

    private void Update()
    {
        if ((GameObject.Find("_Chara") == null))
            StopAllCoroutines();
    }
}


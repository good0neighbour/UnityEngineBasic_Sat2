using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessPopUpUI : MonoBehaviour
{
    [SerializeField] private List<SuccessStar> _stars;
    [SerializeField] private float _starShowingTerm = 0.5f;

    private void OnEnable()
    {
        StartCoroutine(E_ShowStars());
    }

    private IEnumerator E_ShowStars()
    {
        int count = 0;
        while (count < _stars.Count)
        {
            _stars[count].Show();
            yield return new WaitForSeconds(_starShowingTerm);
        }
    }
}

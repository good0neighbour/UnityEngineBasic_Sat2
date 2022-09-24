using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTextManager : MonoBehaviour
{
    public static PopUpTextManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private PopUpText _popUpTextBad;
    [SerializeField] private PopUpText _popUpTextMiss;
    [SerializeField] private PopUpText _popUpTextGood;
    [SerializeField] private PopUpText _popUpTextGreat;
    [SerializeField] private PopUpText _popUpTextCool;
    [SerializeField] private PopUpText _comboText;

    public void PopUp(HitType hitType)
    {
        switch (hitType)
        {
            case HitType.Bad:
                _popUpTextBad.PopUp();
                _popUpTextBad.transform.Translate(Vector3.back);
                _popUpTextMiss.transform.Translate(Vector3.forward);
                _popUpTextGood.transform.Translate(Vector3.forward);
                _popUpTextGreat.transform.Translate(Vector3.forward);
                _popUpTextCool.transform.Translate(Vector3.forward);
                break;
            case HitType.Miss:
                _popUpTextMiss.PopUp();
                _popUpTextBad.transform.Translate(Vector3.forward);
                _popUpTextMiss.transform.Translate(Vector3.back);
                _popUpTextGood.transform.Translate(Vector3.forward);
                _popUpTextGreat.transform.Translate(Vector3.forward);
                _popUpTextCool.transform.Translate(Vector3.forward);
                break;
            case HitType.Good:
                _popUpTextGood.PopUp();
                _popUpTextBad.transform.Translate(Vector3.forward);
                _popUpTextMiss.transform.Translate(Vector3.forward);
                _popUpTextGood.transform.Translate(Vector3.back);
                _popUpTextGreat.transform.Translate(Vector3.forward);
                _popUpTextCool.transform.Translate(Vector3.forward);
                break;
            case HitType.Great:
                _popUpTextGreat.PopUp();
                _popUpTextBad.transform.Translate(Vector3.forward);
                _popUpTextMiss.transform.Translate(Vector3.forward);
                _popUpTextGood.transform.Translate(Vector3.forward);
                _popUpTextGreat.transform.Translate(Vector3.back);
                _popUpTextCool.transform.Translate(Vector3.forward);
                break;
            case HitType.Cool:
                _popUpTextCool.PopUp();
                _popUpTextBad.transform.Translate(Vector3.forward);
                _popUpTextMiss.transform.Translate(Vector3.forward);
                _popUpTextGood.transform.Translate(Vector3.forward);
                _popUpTextGreat.transform.Translate(Vector3.forward);
                _popUpTextCool.transform.Translate(Vector3.back);
                break;
            default:
                break;
        }

        if (GameStatus.CurrentCombo > 1)
        {
            _comboText.PopUp(GameStatus.CurrentCombo.ToString());
        }
    }
}

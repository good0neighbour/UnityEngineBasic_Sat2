using UnityEngine;

/// <summary>
/// 개별 노트 데이터
/// 노래 시작 몇 초 뒤에 어떤 키 위치에 떨어져야 하는 노트인지에 대한 정보
/// </summary>
[System.Serializable]
public class NoteData
{
    public KeyCode Key;
    public float Time;
}

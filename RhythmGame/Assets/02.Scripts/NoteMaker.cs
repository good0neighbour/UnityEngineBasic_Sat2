using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class NoteMaker : MonoBehaviour
{
    private SongData _songData;
    private KeyCode[] _keys = { KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.Space, KeyCode.J, KeyCode.K, KeyCode.L };
    [SerializeField] private VideoPlayer _vp;
    [SerializeField] private int _level = 1;
    public bool DoRecord;
    //====================================================================================================
    //***************************************** Public Method ********************************************
    //====================================================================================================
    /// <summary>
    /// 노래 데이터 생성, 녹화 시작
    /// </summary>
    public void StartRecording()
    {
        if (DoRecord)
            return;

        _songData = new SongData(_vp.clip.name, _level);
        _vp.Play();
        DoRecord = true;
    }
    /// <summary>
    /// 키 입력 체크해서 해당 키에 대한 노트 데이터 생성
    /// Update()에서 호출해야 함
    /// </summary>
    public void Recording()
    {
        foreach (KeyCode key in _keys)
        {
            if (Input.GetKeyDown(key))
                CreateNoteData(key);
        }
    }
    /// <summary>
    /// 녹화 중 정지 버튼 누를 시 노래 데이터 저장 후 비디오 멈춤
    /// </summary>
    public void StopRecording()
    {
        if (DoRecord == false)
            return;

        SaveSongData();
        _songData = null;
        _vp.Stop();
    }
    //====================================================================================================
    //***************************************** Private Method *******************************************
    //====================================================================================================
    private void Update()
    {
        if (DoRecord)
            Recording();
    }
    private void CreateNoteData(KeyCode keycode)
    {
        NoteData noteData = new NoteData();

        float time = (float)System.Math.Round(_vp.time, 2);
        noteData.Time = time;
        noteData.Key = keycode;

        _songData.Notes.Add(noteData);
        Debug.Log($"NoteMaker : Note created, {keycode}, {time}");
    }
    private void SaveSongData()
    {
        string dir = UnityEditor.EditorUtility.SaveFilePanel("저장할 곳을 지정하세요", "", $"{_songData.Name}", "json");
        System.IO.File.WriteAllText(dir, JsonUtility.ToJson(_songData));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float rotateSpeed = 200.0f;
    private float h => Input.GetAxis("Horizontal");
    private float v => Input.GetAxis("Vertical");

    private float r => Input.GetAxis("Mouse X");

    /// <summary>
    /// 초기화 이벤트
    /// SceneLoad 시 호출 (GameObject가 활성화 되어있을 때 호출)
    /// 현재 MonoBehaviour가 비활성화 되어있어도 호출
    /// 일반 클래스의 생성자 대용으로 주로 사용 (멤버변수 초기화 등)
    /// </summary>
    private void Awake()
    {
        
    }

    /// <summary>
    /// 초기화 이벤트
    /// GameObject가 활성화 될 때마다 호출
    /// </summary>
    private void OnEnable()
    {
        
    }

    /// <summary>
    /// 에디터 상에서 초기화 이벤트
    /// GameObject에 이 MonoBehaviour를 추가했을 때 호출 (임의로 호출 가능)
    /// Play 모드에서는 호출되지 않음
    /// </summary>
    private void Reset()
    {
        
    }

    /// <summary>
    /// Fixed 프레임마다 호출되는 이벤트
    /// 물리 연산이 적용되는 연산을 처리할 때 사용 (기기의 성능에 영향을 받으면 안 되는 연산들)
    /// </summary>
    void FixedUpdate()
    {
        //transform.position += new Vector3(h, 0.0f, v).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(h, 0.0f, v).normalized * moveSpeed * Time.deltaTime);

        Vector3 deltaRotate = Vector3.up * r * rotateSpeed * Time.deltaTime;
        transform.Rotate(deltaRotate);
    }

    /// <summary>
    /// 매 프레임마다 호출되는 함수
    /// </summary>
    private void Update()
    {

    }

    /// <summary>
    /// 매 프레임마다 호출되는 이벤트
    /// Update() 이후에 호출됨
    /// 특히 Camera 이동연산 등에 사용
    /// </summary>
    private void LateUpdate()
    {
        
    }

    /// <summary>
    /// Gizmos에 렌더링 할 내용을 연산할 때마다 호출되는 함수
    /// Gizmos : 디버깅 등을 위해서 화면상에 그려지는 모든 그래픽적 요소
    /// </summary>
    private void OnDrawGizmos()
    {
        
    }

    /// <summary>
    /// 이 MonoBehaviour를 컴포넌트로 가지는 GameObject가 선택되었을 때만 호출되는 함수
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        
    }

    /// <summary>
    /// GUI : Graphical User Interface
    /// GUI의 이벤트들을 헨들링하는 함수
    /// </summary>
    private void OnGUI()
    {
        
    }

    /// <summary>
    /// 어플 일시정지 / 일시정지 해제 시 호출
    /// </summary>
    /// <param name="pause"></param>
    private void OnApplicationPause(bool pause)
    {
        
    }

    /// <summary>
    /// 현재 선택된 어플리 변경될 때 호출 (지금 어플 선택되면 true, 딴 거 선택하면 false)
    /// </summary>
    /// <param name="focus"></param>
    private void OnApplicationFocus(bool focus)
    {
        
    }

    /// <summary>
    /// 어플 종료될 때 호출
    /// </summary>
    private void OnApplicationQuit()
    {
        
    }

    /// <summary>
    /// 이 MonoBehaviour를 컴포넌트로 가지는 GameObject가 비활성화 될 때 호출
    /// </summary>
    private void OnDisable()
    {
        
    }

    /// <summary>
    /// 이 MonoBehaviour를 컴포넌트로 가지는 GameObject가 파괴될 때 호출
    /// </summary>
    private void OnDestroy()
    {
        // GameObject를 생성하는 로직을 쓰면 안 됨
    }
}

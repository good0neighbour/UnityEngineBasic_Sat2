using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// Awake는 스크립트 인스턴스가 처음 로드될 때 호출
    /// 이 스크립트를 컴포넌트로 가지는 GameObject가 활성화 되어야 호출됨.
    /// 모노비헤이비어는 생성자를 통해서 생성할 수 없기 때문에, 어웨이크에서 멤버들을 초기화 함.
    /// </summary>
    private void Awake()
    {
        Debug.Log("Awake");
    }

    /// <summary>
    /// 이 스크립트 인스턴스가 활성화될때마다 호출됨.
    /// 이 스크립트를 컴포넌트로 가지는 게임 오브젝트가 활성화 될 때마다 호출됨.
    /// </summary>
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    /// <summary>
    /// 모든 멤버변수를 초기값으로 설정 Editor에서만 동작
    /// 스크립트 인스턴스를 Editor에서 GameObject에 AddComponent 했을때 호출
    /// </summary>
    private void Reset()
    {
        Debug.Log("Reset");
    }

    /// <summary>
    /// 프레임 시작 전에 한번만 호출됨.
    /// Awake로 초기화를 완료한 다른 객체들의 참조를 통해서 초기화해야하는 값들이 있는경우?
    /// 처음에 객체들을 한번 생성해야하는 경우 등에 사용할 수 있다.
    /// </summary>
    private void Start()
    {
        Debug.Log("Start");
    }

    /// <summary>
    /// 고정 프레임속도로 매프레임 호출됨
    /// 물리연산관련 로직은 이 이벤트함수에서 수행해야함
    /// </summary>
    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
    }

    /// <summary>
    /// Trigger가 다른 collider와 겹치는  순간에 호출됨.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name}이(가)트리거됨");
    }

    /// <summary>
    /// trigger 다른 collider 와 겹쳐있으면 계속 호출됨.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"{other.name}이(가)트리거되는중");
    }

    /// <summary>
    /// trigger가 다른 collider와 겹쳐있다가 벗어나는 순간 호출됨.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.name}이(가)트리거해제됨");
    }

    /// <summary>
    /// Collider 또는 Rigidbody가 다른 Rigidbody/Collider 와 충돌하는 순간 호출
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name}이(가)충돌함");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name}이(가)충돌중");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name}이(가)충돌끝남");
    }

    private void OnMouseOver()
    {
        Debug.Log("마우스가 가리키는중...");
    }

    /// <summary>
    /// 매 프레임마다 호출
    /// 기기 성능마다 프레임 주기는 달라짐
    /// </summary>
    private void Update()
    {
        //Debug.Log("Update");
    }

    /// <summary>
    /// 매 프레임마다 호출
    /// Update및Coroutine(Yild)등의 모든 로직연산 후 마지막에 호출됨.
    /// </summary>
    private void LateUpdate()
    {
        //Debug.Log("LateUpdate");
    }

    /// <summary>
    /// Editor에서 Gizmo 랜더링 하기위한 연산을 할때 호출하는 함수
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(Vector3.up * 2.0f, Vector3.one*2.0f);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(Vector3.up * 1.0f + Vector3.right * 1.0f, 1.0f);
    }

    private void OnApplicationPause(bool pause)
    {
        
    }

    /// <summary>
    /// 스크립트 인스턴스가 비활성화 할때마다 호출
    /// </summary>
    private void OnDisable()
    {
        Debug.Log("Disable");
    }

    /// <summary>
    /// 스크립트 인스턴스가 파괴될때 호출
    /// </summary>
    private void OnDestroy()
    {
        Debug.Log("Destroy");
    }
}

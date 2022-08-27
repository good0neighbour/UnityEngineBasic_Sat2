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
    /// �ʱ�ȭ �̺�Ʈ
    /// SceneLoad �� ȣ�� (GameObject�� Ȱ��ȭ �Ǿ����� �� ȣ��)
    /// ���� MonoBehaviour�� ��Ȱ��ȭ �Ǿ��־ ȣ��
    /// �Ϲ� Ŭ������ ������ ������� �ַ� ��� (������� �ʱ�ȭ ��)
    /// </summary>
    private void Awake()
    {
        
    }

    /// <summary>
    /// �ʱ�ȭ �̺�Ʈ
    /// GameObject�� Ȱ��ȭ �� ������ ȣ��
    /// </summary>
    private void OnEnable()
    {
        
    }

    /// <summary>
    /// ������ �󿡼� �ʱ�ȭ �̺�Ʈ
    /// GameObject�� �� MonoBehaviour�� �߰����� �� ȣ�� (���Ƿ� ȣ�� ����)
    /// Play ��忡���� ȣ����� ����
    /// </summary>
    private void Reset()
    {
        
    }

    /// <summary>
    /// Fixed �����Ӹ��� ȣ��Ǵ� �̺�Ʈ
    /// ���� ������ ����Ǵ� ������ ó���� �� ��� (����� ���ɿ� ������ ������ �� �Ǵ� �����)
    /// </summary>
    void FixedUpdate()
    {
        //transform.position += new Vector3(h, 0.0f, v).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(h, 0.0f, v).normalized * moveSpeed * Time.deltaTime);

        Vector3 deltaRotate = Vector3.up * r * rotateSpeed * Time.deltaTime;
        transform.Rotate(deltaRotate);
    }

    /// <summary>
    /// �� �����Ӹ��� ȣ��Ǵ� �Լ�
    /// </summary>
    private void Update()
    {

    }

    /// <summary>
    /// �� �����Ӹ��� ȣ��Ǵ� �̺�Ʈ
    /// Update() ���Ŀ� ȣ���
    /// Ư�� Camera �̵����� � ���
    /// </summary>
    private void LateUpdate()
    {
        
    }

    /// <summary>
    /// Gizmos�� ������ �� ������ ������ ������ ȣ��Ǵ� �Լ�
    /// Gizmos : ����� ���� ���ؼ� ȭ��� �׷����� ��� �׷����� ���
    /// </summary>
    private void OnDrawGizmos()
    {
        
    }

    /// <summary>
    /// �� MonoBehaviour�� ������Ʈ�� ������ GameObject�� ���õǾ��� ���� ȣ��Ǵ� �Լ�
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        
    }

    /// <summary>
    /// GUI : Graphical User Interface
    /// GUI�� �̺�Ʈ���� ��鸵�ϴ� �Լ�
    /// </summary>
    private void OnGUI()
    {
        
    }

    /// <summary>
    /// ���� �Ͻ����� / �Ͻ����� ���� �� ȣ��
    /// </summary>
    /// <param name="pause"></param>
    private void OnApplicationPause(bool pause)
    {
        
    }

    /// <summary>
    /// ���� ���õ� ���ø� ����� �� ȣ�� (���� ���� ���õǸ� true, �� �� �����ϸ� false)
    /// </summary>
    /// <param name="focus"></param>
    private void OnApplicationFocus(bool focus)
    {
        
    }

    /// <summary>
    /// ���� ����� �� ȣ��
    /// </summary>
    private void OnApplicationQuit()
    {
        
    }

    /// <summary>
    /// �� MonoBehaviour�� ������Ʈ�� ������ GameObject�� ��Ȱ��ȭ �� �� ȣ��
    /// </summary>
    private void OnDisable()
    {
        
    }

    /// <summary>
    /// �� MonoBehaviour�� ������Ʈ�� ������ GameObject�� �ı��� �� ȣ��
    /// </summary>
    private void OnDestroy()
    {
        // GameObject�� �����ϴ� ������ ���� �� ��
    }
}

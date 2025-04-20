using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject gPlayer = null; //�÷��̾� ������Ʈ ����
    Vector3 vPlayerPos = Vector3.zero; //�÷��̾��� ��ġ�� �����ϱ� ���� ���� ����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gPlayer = GameObject.Find("player"); //Find �޼ҵ带 ��뤾�� player ������Ʈ�� ã�ƿ´�.
    }

    // Update is called once per frame
    void Update()
    {
        f_PlayerCamPosSync(); //�÷��̾��� ��ġ�� ���� ī�޶��� ��ġ�� ����ȭ�ϴ� �޼ҵ�
    }

    void f_PlayerCamPosSync()
    {
        vPlayerPos = gPlayer.transform.position; //�÷��̾��� ��ġ�� ���� ������ ����

        transform.position = new Vector3(transform.position.x, vPlayerPos.y, transform.position.z); //���� ī�޶��� y�� ���� �÷��̾� ��ġ�� ����
    }
}

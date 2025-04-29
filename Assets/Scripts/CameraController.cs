/*
 * �÷��̾ ȭ�鿡 ������ �ʴ� �� ���ʱ��� �̵��ϸ�, ī�޶� ���� �� �� ���� ������ �߻�
 * �� �������� �ذ��ϱ� ���ؼ���, ī�޶� �÷��̾ ����ٴϸ� ������ �� �ֵ��� ��ũ��Ʈ �ۼ�
 */
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject m_gPlayer = null; //�÷��̾� ������Ʈ ����
    GameObject m_gCam = null;   //ī�޶� ������Ʈ ����
    Vector3 vPlayerPos = Vector3.zero; //�÷��̾��� y��ǥ�� �����ϱ� ���� ���� ����

    float fCamY = 0.0f; //ī�޶��� y��ǥ ����
    bool isPlayerOnGround = false;  //�÷��̾ ���鿡 ��Ҵ��� ���� bool����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_gPlayer = GameObject.Find("player"); //Find �޼ҵ带 ��뤾�� player ������Ʈ�� ã�ƿ´�.
        m_gCam = GameObject.Find("Main Camera");//ī�޶� ������Ʈ ã�ƿ´�
    }

    // Update is called once per frame
    void Update()
    {
        f_PlayerCamPosSync(); //�÷��̾��� ��ġ�� ���� ī�޶��� ��ġ�� ����ȭ�ϴ� �޼ҵ�

        f_CamRangeLimit();  //ī�޶� ȭ�� �Ʒ��� �������� �ʵ��� ��ġ�� �����ϴ� �޼ҵ�
    }

    void f_PlayerCamPosSync()
    {
        /*
         * �÷��̾ ���� �̵��� ������ ī�޶� ����ٴϵ��� �����Ӹ��� �÷��̾� ��ǥ�� ���ؼ� ����
         * �÷��̾� �̵��� ī�޶� ���󰡴� ���� Y�� ����(����)�� ��ȭ�̹Ƿ� ������ ���� Y��ǥ���� �ݿ��Ѵ�.
         * X, Z��ǥ�� ������ �����Ƿ� ī�޶��� ���� ��ǥ�� �״�� ���
         */

        vPlayerPos = m_gPlayer.transform.position; //�÷��̾��� ��ġ�� ���� ������ ����

        if (isPlayerOnGround == false)//�÷��̾ �ٴڿ� �ִ°� �ƴ϶��
        {
            transform.position = new Vector3(transform.position.x, vPlayerPos.y, transform.position.z); //���� ī�޶��� y�� ���� �÷��̾� ��ġ�� ����
        }
    }
    void f_CamRangeLimit()
    {
        if (vPlayerPos.y < 0.0f) //�÷��̾ ���鿡 ���� ��� true�� ��ȯ
        {
            isPlayerOnGround = true;
        }
        else
        {
            isPlayerOnGround = false;
        }

        if (isPlayerOnGround == true)   //ī�޶��� y��ǥ�� 0���� �����Ͽ� ���� �ٱ��� ������ �ʵ��� ����
        {
            transform.position = new Vector3(transform.position.x, fCamY, transform.position.z);
        }
    }
}

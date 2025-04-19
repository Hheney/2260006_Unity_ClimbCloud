/*
 * ����ڰ� �Է��� ��� �÷��̰� �¿�� �����̰ų� ����(�پ������ ���)
 * �����̽��ٸ� ������ �����ϰ�, Ű���忡 �ִ� �¿� ȭ��ǥ Ű(��, ��)�� ������ �̵��ϴ� ��Ʈ�ѷ� ��ũ��Ʈ�� �ۼ�
 * 1. �����̽��ٸ� ������ ����
 * 2. �÷��̾ �¿�� �����̱�
 */
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Cat ������Ʈ�� Rigidbody2D ������Ʈ�� ���� ��� ����(m_)
    Rigidbody2D m_rigid2DCat = null;

   
    float fJumpForce = 680.0f; //�÷��̾ ���� �� ���� ������ ����
    float fWalkForce = 30.0f; //�÷��̾� ��, ��� �����̴� ���ӵ�
    float fMaxWalkSpeed = 2.0f; //�÷��̾��� �̵� �ӵ��� ������ �ְ� �ӵ�
    int nLeftRightKeyValue = 0; //�÷��̾� �¿� ������ Ű �� : ������ ȭ�� Ű: 1, ���� ȭ�� Ű: -1, �������� ���� ��: 0

    float fPlayerMoveSpeed = 0.0f; //�÷��̾� �¿� �����̴� �ӵ�

    //�÷��̾� �̵� �ӵ��� ���� �ִϸ��̼� ��� �ӵ��� ����ϱ� ���� �ִϸ����� ���� ����
    Animator m_animatorCat = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
         * ����̽� ���ɿ� ���� ���� ����� ���� ���ֱ�
         * � ������ ��ǻ�Ϳ��� �����ص� ���� �ӵ��� �����̵��� �ϴ� ó��
         * ����Ʈ���� 60, ����� PC�� 300�� �� �� �ִ� ����̽� ���ɿ� ���� ���� ���ۿ� ������ ��ĥ �� �ִ�.
         * �����ӷ���Ʈ�� 60���� ����
         */
        Application.targetFrameRate = 60;

        /*
         * Ư�� ������Ʈ�� ������Ʈ�� �����ϱ� ���ؼ��� GetComponent �Լ��� ���
         * Rigidbody2D ������Ʈ�� ���� �޼ҵ带 ����ϱ� ������ Start �޼ҵ忡�� GetComponent �޼ҵ带 ����ؼ�
         * Rigidbody2D ������Ʈ�� ���� ��� ������ ����
         */
        m_rigid2DCat = GetComponent<Rigidbody2D>();

        //GetComponent �޼ҵ带 ����� Animator ������Ʈ�� ����
        m_animatorCat = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * AddForce �޼ҵ� : ������Ʈ�� ������ ���� �־� �̵���Ű�� ��
         * Spacebar Key�� ������ GetKeyDown �޼ҵ� AddForce �޼ҵ带 ����� ���� �������� ������ �÷��̾ ���� ���Ѵ�.
         * ��, �÷��̾ ���� ���Ϸ��� Rigidbody2D ������Ʈ�� ���� AddForce �޼ҵ带 ����Ѵ�.
         */
        if (Input.GetKeyDown(KeyCode.Space) && m_rigid2DCat.linearVelocity.y == 0)
        {
            m_animatorCat.SetTrigger("JumpTrigger");
            m_rigid2DCat.AddForce(transform.up * fJumpForce);
        }

        /*
         * �÷��̾� ��, �� �̵�
         * �÷��̾� �¿� ������ Ű �� : ������ ȭ�� Ű: 1, ���� ȭ�� Ű: -1, �������� ���� ��: 0
         */

        if(Input.GetKey(KeyCode.RightArrow))
        {
            nLeftRightKeyValue = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            nLeftRightKeyValue = -1;
        }

        /*
         * �÷��̾��� ���ǵ� ����
         * �����Ӹ��� AddForce �޼ҵ带 ����� ���� ���ϸ� �÷��̾ ��� ������ �Ǵ� ������ �߻�
         * �׷��� �÷��̾��� �̵��ӵ��� ������ �ְ�ӵ� ���� ������ ���� ���ϴ� ���� ���߰� �ӵ��� ����
         * ����ȭ��ǥ, ������ȭ��ǥ Key�� ������ AddForce �޼ҵ带 ����� ��, �� �������� ������ �÷��̾ ���� ���Ѵ�.
         * �� , �÷��̾ ���� ���Ϸ��� Rigidbody2D ������Ʈ�� ���� AddForve �޼ҵ带 ����Ѵ�.
         * Velocity : ���� ���� ���ص� ������ �ӵ��� �޸� �� �ֵ��� ���������� �ڵ����� ���
         * AddForce�� ��� ���������� Ƣ�� ������ ���� �ӵ��� �پ��鼭 �������� ������ ����
         * Velocity�� ������ �ӵ��� �޸��� ���ʰ��� ĳ���� �̵��� ����
         */
        fPlayerMoveSpeed = Mathf.Abs(m_rigid2DCat.linearVelocity.x);

        if(fPlayerMoveSpeed < fMaxWalkSpeed)
        {
            m_rigid2DCat.AddForce(transform.right * fWalkForce * nLeftRightKeyValue);
        }

        /*
         * �����̴� ���⿡ ���� �÷��̾� �̹����� ����
         * �÷��̾ ���������� �����̸� ��Ʈ����Ʈ�� ���������� ���ϰ�,
         * �������� �����̸� �������� �����̵��� �̹����� ������Ű����,
         * ��������Ʈ�� X�� ��������� -1��� ��
         * ��������Ʈ�� ������ �ٲٷ��� tranform ������Ʈ�� localScale ���� ���� ����
         * ������ ȭ��ǥ�� 1��, ����ȭ��ǥ�� X�� �������� -1��
         */
        if(nLeftRightKeyValue !=0)
        {
            transform.localScale = new Vector3(nLeftRightKeyValue, 1.0f, 1.0f);
        }

        /*
         * �ִϸ��̼� ��� �ӵ��� �÷��̾� �̵� �ӵ��� ����ϵ��� ����
         * �÷��̾� �̵� �ӵ��� 0�̸� �ִϸ��̼� �̵� �ӵ��� 0���� �����ϰ�,
         * �÷��̾� �̵� �ӵ��� ���������� �ִϸ��̼� �ӵ��� ������
         * �ִϸ��̼� ��� �ӵ��� �ٲٷ��� ������Ʈ�� speed ���������� ����
         */
        //m_animatorCat.speed = fPlayerMoveSpeed / 1.0f;


        if(m_rigid2DCat.linearVelocity.y == 0)
        {
            m_animatorCat.speed = fPlayerMoveSpeed / 2.0f;
        }
        else
        {
            m_animatorCat.speed = 1.0f;
        }


    }
}

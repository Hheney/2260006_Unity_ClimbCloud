/*
 * ����ڰ� �Է��� ��� �÷��̰� �¿�� �����̰ų� ����(�پ������ ���)
 * �����̽��ٸ� ������ �����ϰ�, Ű���忡 �ִ� �¿� ȭ��ǥ Ű(��, ��)�� ������ �̵��ϴ� ��Ʈ�ѷ� ��ũ��Ʈ�� �ۼ�
 * 1. �����̽��ٸ� ������ ����
 * 2. �÷��̾ �¿�� �����̱�
 */
using Unity.Hierarchy;
<<<<<<< Updated upstream
using UnityEditor.Timeline;
using UnityEngine;
=======
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.SceneManagement;
>>>>>>> Stashed changes

public class PlayerController : MonoBehaviour
{
    float fMaxPosition = 2.1f;  //�÷��̾ ��, �� �̵��� ����â�� ����� �ʵ��� Vector �ִ밪 ���� ����
    float fMinPosition = -2.1f; //�÷��̾ ��, �� �̵��� ����â�� ����� �ʵ��� Vector �ּҰ� ���� ����
    float fPositionX = 0.0f;    //�÷��̾��� ��ġ ����

    //Cat ������Ʈ�� Rigidbody2D ������Ʈ�� ���� ��� ����(m_)
    Rigidbody2D m_rigid2DCat = null;

    float fJumpForce = 680.0f; //�÷��̾ ���� �� ���� ������ ����
    float fWalkForce = 30.0f; //�÷��̾� ��, ��� �����̴� ���ӵ�
    float fMaxWalkSpeed = 2.0f; //�÷��̾��� �̵� �ӵ��� ������ �ְ� �ӵ�
    int nLeftRightKeyValue = 0; //�÷��̾� �¿� ������ Ű �� : ������ ȭ�� Ű: 1, ���� ȭ�� Ű: -1, �������� ���� ��: 0

    float fPlayerMoveSpeed = 0.0f; //�÷��̾� �¿� �����̴� �ӵ�

    //�÷��̾� �̵� �ӵ��� ���� �ִϸ��̼� ��� �ӵ��� ����ϱ� ���� �ִϸ����� ���� ����
    Animator m_animatorCat = null;

    //��ȭ ���� ��ͱ���
    float fSpacebarPressTime = 0.0f;        //�����̽��ٸ� ���� �ð� ����
    float fMaxSpacebarPressTime = 1.0f;     //������ �����̽��� �ð��� �ִ� �ð� ���� (�⺻�� : 1.0f)
    [SerializeField] float fMinReinforceJumpForce = 500.0f;  //�÷��̾��� �ּ� ���� ���ӵ�
    [SerializeField] float fMaxReinforceJumpForce = 800.0f;  //�÷��̾��� �ִ� ���� ���ӵ�

    float fReinforceJumpForce = 0.0f;   //�÷��̾ ���� �� ���� �����ϴ� ��ȭ ���� ����
    float fReinforceJumpRatio = 0.0f;   //�÷��̾ ����� �� �ִ� ��ȭ ������ ���� ����

    bool isSpacebarPress = false;   //�����̽��ٰ� �������ִ��� ����
    bool isPlayerOnCloud = false;   //�÷��̾ �������� �ִ��� ����

<<<<<<< Updated upstream
=======
    //GameObject m_StageClear = null;

>>>>>>> Stashed changes
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
         * Ư�� ������Ʈ�� ������Ʈ�� �����ϱ� ���ؼ��� GetComponent �Լ��� ���
         * Rigidbody2D ������Ʈ�� ���� �޼ҵ带 ����ϱ� ������ Start �޼ҵ忡�� GetComponent �޼ҵ带 ����ؼ�
         * Rigidbody2D ������Ʈ�� ���� ��� ������ ����
         */
        m_rigid2DCat = GetComponent<Rigidbody2D>();

        //GetComponent �޼ҵ带 ����� Animator ������Ʈ�� ����
        m_animatorCat = GetComponent<Animator>();
<<<<<<< Updated upstream
=======

        //m_StageClear = GameObject.Find("StageClear");
        //m_StageClear.SetActive(false);

>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        //f_PlayerJump();           //�÷��̾ 'SpaceBar'�� ������ �����ϴ� �޼ҵ�
        f_PlayerReinforceJump();    //�÷��̾ 'SpaceBar'�� ��� ������ ��ȭ ������ �ϴ� �޼ҵ�
        f_ReinforceJumpEffect();    //��ȭ ������ ���� 'SpaceBar'�� ��� ������ ���� ����Ʈ�� �߻���Ű�� �޼ҵ�
        f_PlayerMoveAxisX();        //�÷��̾ ��, ��� �̵���Ű�� �޼ҵ�
        f_PlayerMoveSpeedLimit();   //�÷��̾��� �̵� �ӵ��� �����ϴ� �޼ҵ�

        f_SwitchPlayerDirection();  //�÷��̾ �ٶ󺸴� ������ ��ȯ���ִ� �޼ҵ�
        f_SyncAnimationSpeed();     //�÷��̾��� �ӵ��� ���� �ִϸ��̼� �ӵ��� ����ȭ��Ű�� �޼ҵ�
        
        f_PlayerRangeLimit();       //�÷��̾ ȭ������� ����� �ʰ� �ϴ� �޼ҵ�
        f_PlayerFallingGround();    //�÷��̾ ������ �����ϸ� ������ �ٽ� �����ϴ� �޼ҵ�
    }

    void f_PlayerMoveAxisX()
    {
        //nLeftRightKeyValue = 0;
        //�������� ���� ���, ���������� nLeftRightKeyValue�� �⺻���� 0���� �ٽ� �ʱ�ȭ
        //�÷��̾�� �Է��� ���� ��� �������� �ʰ� �ȴ�.

        /*
         * �÷��̾� ��, �� �̵�
         * �÷��̾� �¿� ������ Ű �� : ������ ȭ�� Ű: 1, ���� ȭ�� Ű: -1, �������� ���� ��: 0
         */
        if (Input.GetKey(KeyCode.RightArrow))
        {
            nLeftRightKeyValue = 1;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            nLeftRightKeyValue = -1;
        }
        else
        {
            nLeftRightKeyValue = 0;
        }
    }

    void f_PlayerJump()
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
    }

    void f_PlayerReinforceJump()
    {
        /*
         * [���̵��] : �����̽��ٸ� ��� ������ �� ���� ���� (��ȭ ����)
         * [����� ���] : ���� ������
         * [����] : ���� ������(����������, linear interpolation)�� ������ ���� �־����� �� �� ���̿� ��ġ�� ���� �����ϱ� ���Ͽ� ���� �Ÿ��� ���� ���������� ����ϴ� ����̴�.
         * [�����̶�] : �˷��� �� ���̿� ���� ���� �����ϰų� �����ִ� ���� �ǹ��Ѵ�.
         * Unity���� �����ϴ� Mathf.Lerp �޼ҵ�� ����(Interpolation) ��� �� �ϳ��� ���� ����(Linear Interpolation)�� �����Ѵ�.
         */

        /* ����� �� linearVelocity.y ������ ��ȣ�Ͽ� ���߿��� ������ �� �ִ� ��찡 �����Ǿ� ����
   
<<<<<<< Updated upstream
        //�÷��̾��� y�� ���ӵ��� 0�̸� �÷��̾ ���� ���� �ִ� ������ �Ǵ��Ѵ�. 
        if (m_rigid2DCat.linearVelocity.y == 0)
        {
            isPlayerOnCloud = true;
        }*/
=======
        //�÷��̾��� y�� ���ӵ��� 0�̸� �÷��̾ ���� ���� �ִ� ������ �Ǵ��Ѵ�. */
        if (m_rigid2DCat.linearVelocity.y == 0)
        {
            isPlayerOnCloud = true;
        }
>>>>>>> Stashed changes

        //�÷��̾ ���� ���� �ְ� �����̽��ٸ� ���� ���, ���� �ð� �ʱ�ȭ �� ������ ���� bool ���� ��ȯ
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerOnCloud)
        {
            fSpacebarPressTime = 0.0f; //���� �ð� �ʱ�ȭ

            isSpacebarPress = true; //�����̽��� ����

            Debug.Log("PressTime : " + fSpacebarPressTime);
        }

        //�����̽��ٸ� ������ ������ ���� �ð��� deltaTime ��ŭ �����Ѵ�.
        if (Input.GetKey(KeyCode.Space) && isSpacebarPress)
        {
            fSpacebarPressTime += Time.deltaTime;

            //�ִ� �����̽��� �ð��� ���� ���ϵ��� �� �Ű����� �� �ּڰ� ��ȯ
            fSpacebarPressTime = Mathf.Min(fSpacebarPressTime, fMaxSpacebarPressTime);

            /*
             * Mathf.Clamp �޼ҵ带 ����Ͽ��� ���� ����� �����ϳ�, ���Ѱ��� �����ϸ� �Ǳ⶧���� Mathf.Min�� �����
             * Mathf.Clamp(float a, float min, float max)
             * Mathf.Min(float a, float b)
             */
        }

        //�����̽��ٸ� ���ٸ� ���� �ð��� ����Ͽ� ��ȭ�� ������ �����Ѵ�.
        if (Input.GetKeyUp(KeyCode.Space) && isSpacebarPress && isPlayerOnCloud)
        {
            //��ȭ ���� ���� = �����̽��� ���� �ð� / �ִ� �����̽��� �ð�
            fReinforceJumpRatio = fSpacebarPressTime / fMaxSpacebarPressTime;

            //��ȭ ���� ���ӵ�= ���� ����(�ּ� ��, �ִ� ��, ��ȭ ���� ����)
            fReinforceJumpForce = Mathf.Lerp(fMinReinforceJumpForce, fMaxReinforceJumpForce, fReinforceJumpRatio);

            m_animatorCat.SetTrigger("JumpTrigger"); //���� �ִϸ��̼� Ȱ��ȭ
            m_rigid2DCat.AddForce(transform.up * fReinforceJumpForce); //��ȭ ���� �� ��ŭ up �������� ���� ����

<<<<<<< Updated upstream
=======
            SoundManager.Instance.f_PlaySFX(SoundName.SFX_Jump, 0.1f); //���� ȿ���� 10% �������� ���

>>>>>>> Stashed changes
            Debug.Log("Jump Ratio: " + fReinforceJumpRatio + ", Force: " + fReinforceJumpForce);
            isSpacebarPress = false; //�����̽��� ������
        }
    }

    void f_ReinforceJumpEffect()
    {
        //PingPong �޼ҵ带 ����Ͽ� 1.0f�ʿ� 5��(Time.time * 5) �����̴� ȿ���� �����ϱ� ���� ������ �ֱ� ����
        //�� �޼ҵ� ���ο����� ���ǹǷ� �������� ����
        float fBlinkSpan = Mathf.PingPong(Time.time * 5, 1.0f);

        if(isSpacebarPress)
        {
            //����� ������� ������ �ֱ⸸ŭ ��ȯ��
            GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.yellow, fBlinkSpan);
        }
        else
        {
            //�����̽��ٸ� ������ ������ ������� ����
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void f_PlayerMoveSpeedLimit()
    {
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

        if (fPlayerMoveSpeed < fMaxWalkSpeed)
        {
            m_rigid2DCat.AddForce(transform.right * fWalkForce * nLeftRightKeyValue);
        }
    }

    void f_SwitchPlayerDirection()
    {
        /*
         * �����̴� ���⿡ ���� �÷��̾� �̹����� ����
         * �÷��̾ ���������� �����̸� ��Ʈ����Ʈ�� ���������� ���ϰ�,
         * �������� �����̸� �������� �����̵��� �̹����� ������Ű����,
         * ��������Ʈ�� X�� ��������� -1��� ��
         * ��������Ʈ�� ������ �ٲٷ��� tranform ������Ʈ�� localScale ���� ���� ����
         * ������ ȭ��ǥ�� 1��, ����ȭ��ǥ�� X�� �������� -1��
         */
        if (nLeftRightKeyValue != 0)
        {
            transform.localScale = new Vector3(nLeftRightKeyValue, 1.0f, 1.0f);
        }
    }

    void f_SyncAnimationSpeed()
    {
        /*
         * �ִϸ��̼� ��� �ӵ��� �÷��̾� �̵� �ӵ��� ����ϵ��� ����
         * �÷��̾� �̵� �ӵ��� 0�̸� �ִϸ��̼� �̵� �ӵ��� 0���� �����ϰ�,
         * �÷��̾� �̵� �ӵ��� ���������� �ִϸ��̼� �ӵ��� ������
         * �ִϸ��̼� ��� �ӵ��� �ٲٷ��� ������Ʈ�� speed ���������� ����
         */
        //m_animatorCat.speed = fPlayerMoveSpeed / 1.0f;

        if (m_rigid2DCat.linearVelocity.y == 0)
        {
            m_animatorCat.speed = fPlayerMoveSpeed / 2.0f;
        }
        else
        {
            m_animatorCat.speed = 1.0f;
        }
    }

    void f_PlayerRangeLimit()
    {
        //Clamp �޼ҵ带 ����Ͽ� x��ǥ���� ������ ������ �� ����
        fPositionX = Mathf.Clamp(transform.position.x, fMinPosition, fMaxPosition);

        //������ �� ������ ����
        transform.position = new Vector3(fPositionX, transform.position.y, transform.position.z);
    }

    void f_PlayerFallingGround()
    {
        //-4.5f(���ϴ�) ���Ϸ� �÷��̾ ���Ͻ� �÷��̾� ������Ʈ �ı� �� �� �ٽ� �ҷ�����
        if(transform.position.y < -4.5f)
        {
            //Destroy(gameObject);
<<<<<<< Updated upstream
            //SceneManager.LoadScene("GameScene");
            //GameManager.Instance.f_RestartGame();
            transform.position = new Vector3(0, 0, 0);  //�� �߰��� ���� �÷��̾��� �⺻ ��ġ�� ������ �װ����� �ٽ� �����ϵ��� ����
=======
            SoundManager.Instance.f_PlaySFX(SoundName.SFX_GameOver, 0.1f); //���� ���� ȿ���� 10% �������� ���

            //SceneManager.LoadScene("GameScene");
            //GameManager.Instance.f_RestartGame(); //���� �����

            transform.position = new Vector3(0.0f, -3.0f, 0.0f);    //�ش� ���������� ó������ �ٽ� �����ϵ��� ����
>>>>>>> Stashed changes
        }
    }

    /*
     * �÷��̾ ��߿� ������ ������ �����
     * �� ��� ���Ӿ����� Ŭ���� ������ ��ȯ�Ǿ�� ��
     * �÷��̾ ��߿� ��Ҵ����� OnTriggerEnter2D �޼ҵ�� ������
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ŭ����!");
<<<<<<< Updated upstream
        //SceneManager.LoadScene("ClearScene");

        GameManager.Instance.f_ClearGame(); 
=======
        //SoundManager.Instance.f_PlaySFX(SoundName.SFX_GameClear, 0.1f); //���� Ŭ���� ȿ���� 10% �������� ���

        //SceneManager.LoadScene("ClearScene");
        //GameManager.Instance.f_ClearGame();

        //if (collision.gameObject.CompareTag("Flag"))
        //{
        //    m_StageClear.SetActive(true);
        //}
    }

    public void ContinueDownFirst()
    {
        SceneManager.LoadScene("GameScene");
        SoundManager.Instance.f_StopAllSounds();    //���� ����
        SoundManager.Instance.f_PlayBGM(SoundName.BGM_StageBGM2, 0.1f); //2�������� ���� ���
    }

    public void ContinueDownSecond()
    {
        SceneManager.LoadScene("ThirdScene");
        SoundManager.Instance.f_StopAllSounds();    //���� ����
        //SoundManager.Instance.f_PlayBGM(SoundName.BGM_StageBGM3, 0.1f); //3�������� ���� ���
>>>>>>> Stashed changes
    }

    /*
     * Cloud Tag�� �ν��Ͽ� isPlayerOnCloud�� ��, ���� ���� �����ϵ��� �غ�������, ���������� �浹�� �������� ���ϴ� ��Ȳ�� �߻�
     * �ش� ������ ������ ���, �÷��̾�� ���� ���� �������� ������ �ٽ� ���� ���ϴ� ��Ȳ�� �߻��Ѵ�.
     * player ������Ʈ ���� Rigidbody2D ������Ʈ�� Collision Detection�� Discrete�� �����Ǿ� �־� �ͳθ� ������ �߻��ϴ� ���� Ȯ����.
     * ���� �ش� �������� Discrete �� Continuous�� �����Ͽ� �浹 ������ ��ȭ��.
     * �㳪 Continuous�� ����ϹǷ� �����ս� ����� ����(�ý��� �ڿ��� �� �Ҹ�)�ϴ� �������� ������.
     * Raycast ����� ����Ѵٸ� ���� ������ ������ ������.
     */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�÷��̾��� �������� ����
        //Debug.Log("�浹�� ��ü: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Cloud"))
        {
            //Debug.Log("�÷��̾ ������");
            isPlayerOnCloud = true; //�÷��̾� ���� ��

            /*
             * �÷��̾ ������ �浹�� ��� �浹�� ������Ʈ�� FallingCloud ��ũ��Ʈ�� �����ϴ°�?
             * �Ʒ��� ���� �ۼ��� ������ GetComponent �޼ҵ��� ��� �ƹ��͵� ���� ��� ��ȯ�� null������ ������
             * ���� if������ null������ �˻��ϴ� ������ �������� ������ ������ ������ ������ �� �ְԵ�.
             */
            FallingCloud g_fallingCloud = collision.gameObject.GetComponent<FallingCloud>();

            //������Ʈ�� �����Ѵٸ�
            if (g_fallingCloud != null)
            {
                g_fallingCloud.f_ActiveFallingCloud(); //FallingCloud�� f_ActiveFallingCloud �޼ҵ�(�������� ���� ���) ȣ��
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //�÷��̾��� �������� ����
        if (collision.gameObject.CompareTag("Cloud"))
        {
            //Debug.Log("�÷��̾ ������");
            isPlayerOnCloud = false; //�÷��̾� ���� ����
<<<<<<< Updated upstream
        }   
    }
=======
        }
    }
    
>>>>>>> Stashed changes
}

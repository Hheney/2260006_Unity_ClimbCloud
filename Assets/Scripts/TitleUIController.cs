//���θ޴�
//���� �����ϱ�

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    GameObject m_TabStart = null;   //Ÿ��Ʋȭ��
    GameObject m_GameStart = null;  //���θ޴� - ����
    GameObject m_Quit = null;       //���θ޴� - ����


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.Instance.f_StopAllBGM();   //����Ǵ� ���� ����
        SoundManager.Instance.f_PlayBGM(SoundName.BGM_MainMenu, 0.1f);  //���θ޴� ���� ���

        m_TabStart = GameObject.Find("Tab");//Ÿ��Ʋ �ڷ� Find
        m_GameStart = GameObject.Find("GameStart");
        m_Quit = GameObject.Find("Quit");

        m_GameStart.SetActive(false);   //���θ޴� ��Ȱ��ȭ
        m_Quit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    //Ÿ��Ʋȭ�鿡�� ���θ޴��� ��ȯ
        {
            SoundManager.Instance.f_PlaySFX(SoundName.SFX_ButtonClick, 0.7f);
            m_TabStart.SetActive(false);    //Ÿ��Ʋ ��Ȱ��ȭ
            m_GameStart.SetActive(true);    //���θ޴� Ȱ��ȭ
            m_Quit.SetActive(true);
        }
    }

    public void GameStartDown() //���� ���� ��ư
    {
        SoundManager.Instance.f_PlaySFX(SoundName.SFX_ButtonClick, 0.7f);
        SceneManager.LoadScene("FirstStage");   //1���������� �̵�
        SoundManager.Instance.f_StopAllBGM();    //���� ����
        SoundManager.Instance.f_PlayBGM(SoundName.BGM_StageBGM1, 0.1f); //1�������� ���� ���
    }

    public void QuitDown()  //���� ��ư
    {
        SoundManager.Instance.f_PlaySFX(SoundName.SFX_ButtonClick, 0.7f);
        Application.Quit();
    }

}

//public void f_GameStart()
//{
//    SoundManager.Instance.f_StopAllBGM(); //��� ������� ��� ����
//    SoundManager.Instance.f_PlayBGM(SoundName.BGM_StageBGM1, 0.1f);     //��������2 ������� ���
//    SoundManager.Instance.f_PlaySFX(SoundName.SFX_ButtonClick, 1.0f);   //��ư Ŭ�� ȿ���� ���
//    GameManager.Instance.f_GameStart(); //���� ����
//}

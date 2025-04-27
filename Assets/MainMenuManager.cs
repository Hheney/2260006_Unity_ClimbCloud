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
        SoundManager.Instance.f_StopAllSounds();    //����Ǵ� ���� ����
        SoundManager.Instance.f_PlayBGM(SoundName.BGM_MainMenu, 0.1f);  //���θ޴� ���� ���

        m_TabStart = GameObject.Find("Tab");
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
            m_TabStart.SetActive(false);    
            m_GameStart.SetActive(true); 
            m_Quit.SetActive(true);
        }
    }

    public void GameStartDown() //���� ���� ��ư
    {
        SceneManager.LoadScene("FirstStage");   //1���������� �̵�
        SoundManager.Instance.f_StopAllSounds();    //���� ����
        SoundManager.Instance.f_PlayBGM(SoundName.BGM_StageBGM1, 0.1f); //1�������� ���� ���
    }

    public void QuitDown()  //���� ��ư
    {
        Application.Quit();
    }

}

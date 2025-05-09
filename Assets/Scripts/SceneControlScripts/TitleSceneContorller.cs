//���θ޴�
//���� �����ϱ�
//���� �����ϱ�

using JetBrains.Annotations;
using UnityEngine;
using UnityEditor; //EditorApplication ����� ���� ����Ʈ

public class TitleSceneContorller : MonoBehaviour
{
    GameObject m_TabStart = null;   //Ÿ��Ʋȭ��
    GameObject m_GameStart = null;  //���θ޴� - ����
    GameObject m_Quit = null;       //���θ޴� - ����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.Instance.f_StopAllBGM();   //������� ������� ��� ����
        SoundManager.Instance.f_AutoPlayBGM();  //���� �ش��ϴ� ������� ���

        //Ÿ��Ʋ �ڷ� Find
        m_TabStart = GameObject.Find("Tab");
        m_GameStart = GameObject.Find("GameStart");     
        m_Quit = GameObject.Find("Quit");

        //���θ޴� ��Ȱ��ȭ
        m_GameStart.SetActive(false);
        m_Quit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Ÿ��Ʋȭ�鿡�� ���θ޴��� ��ȯ
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.f_PlaySFX(SoundName.SFX_ButtonClick, 0.7f);
            m_TabStart.SetActive(false);    //Ÿ��Ʋ ��Ȱ��ȭ
            m_GameStart.SetActive(true);    //���θ޴� Ȱ��ȭ
            m_Quit.SetActive(true);         //�����ư Ȱ��ȭ
        }
    }

    public void GameStartDown() //���� ���� ��ư
    {
        SoundManager.Instance.f_PlaySFX(SoundName.SFX_ButtonClick, 0.7f); 
        GameManager.Instance.f_OpenScene(SceneName.FirstStage); //��������1 �� �ε�
    }

    public void QuitDown()  //���� ��ư
    {
        SoundManager.Instance.f_PlaySFX(SoundName.SFX_ButtonClick, 0.7f);
        
        //������ ����(������ �󿡼� ���α׷��� ����Ǳ� ������ ������ ������ ����)
        UnityEditor.EditorApplication.isPlaying = false; 
    }

}
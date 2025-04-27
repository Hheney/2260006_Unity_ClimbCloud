//메인메뉴
//게임 시작하기

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    GameObject m_TabStart = null;   //타이틀화면
    GameObject m_GameStart = null;  //메인메뉴 - 시작
    GameObject m_Quit = null;       //메인메뉴 - 종료


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.Instance.f_StopAllSounds();    //재생되던 음악 종료
        SoundManager.Instance.f_PlayBGM(SoundName.BGM_MainMenu, 0.1f);  //메인메뉴 음악 재생

        m_TabStart = GameObject.Find("Tab");
        m_GameStart = GameObject.Find("GameStart");
        m_Quit = GameObject.Find("Quit");

        m_GameStart.SetActive(false);   //메인메뉴 비활성화
        m_Quit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    //타이틀화면에서 메인메뉴로 전환
        {
            m_TabStart.SetActive(false);    
            m_GameStart.SetActive(true); 
            m_Quit.SetActive(true);
        }
    }

    public void GameStartDown() //게임 시작 버튼
    {
        SceneManager.LoadScene("FirstStage");   //1스테이지로 이동
        SoundManager.Instance.f_StopAllSounds();    //사운드 정지
        SoundManager.Instance.f_PlayBGM(SoundName.BGM_StageBGM1, 0.1f); //1스테이지 사운드 재생
    }

    public void QuitDown()  //종료 버튼
    {
        Application.Quit();
    }

}

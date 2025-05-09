//메인메뉴
//게임 시작하기
//게임 종료하기

using JetBrains.Annotations;
using UnityEngine;
using UnityEditor; //EditorApplication 사용을 위해 임포트

public class TitleSceneContorller : MonoBehaviour
{
    GameObject m_TabStart = null;   //타이틀화면
    GameObject m_GameStart = null;  //메인메뉴 - 시작
    GameObject m_Quit = null;       //메인메뉴 - 종료

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.Instance.f_StopAllBGM();   //재생중인 배경음악 재생 중지
        SoundManager.Instance.f_AutoPlayBGM();  //씬에 해당하는 배경음악 재생

        //타이틀 자료 Find
        m_TabStart = GameObject.Find("Tab");
        m_GameStart = GameObject.Find("GameStart");     
        m_Quit = GameObject.Find("Quit");

        //메인메뉴 비활성화
        m_GameStart.SetActive(false);
        m_Quit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //타이틀화면에서 메인메뉴로 전환
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.f_PlaySFX(SoundName.SFX_ButtonClick, 0.7f);
            m_TabStart.SetActive(false);    //타이틀 비활성화
            m_GameStart.SetActive(true);    //메인메뉴 활성화
            m_Quit.SetActive(true);         //종료버튼 활성화
        }
    }

    public void GameStartDown() //게임 시작 버튼
    {
        SoundManager.Instance.f_PlaySFX(SoundName.SFX_ButtonClick, 0.7f); 
        GameManager.Instance.f_OpenScene(SceneName.FirstStage); //스테이지1 씬 로드
    }

    public void QuitDown()  //종료 버튼
    {
        SoundManager.Instance.f_PlaySFX(SoundName.SFX_ButtonClick, 0.7f);
        
        //에디터 종료(에디터 상에서 프로그램이 실행되기 때문에 에디터 실행을 종료)
        UnityEditor.EditorApplication.isPlaying = false; 
    }

}
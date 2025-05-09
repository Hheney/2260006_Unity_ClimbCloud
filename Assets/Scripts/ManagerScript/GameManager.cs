/*
 * 점수, 시간, 플레이어 상태등의 기능 추가 및 밸런싱 공유를 고려하여 싱글톤 패턴의 GameManger 생성
 * 여러 스크립트에서 다중 사용이 될 요소를 통합하여 관리하기 위함
 * 또한 객체지향의 5원칙중 하나인 단일 책임 원칙(Single Responsibility Principle)을 준수하기 위함
 */
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement; //씬을 전환하기 위한 씬매니저 임포트


//씬 이름을 직접입력하는 문자열 하드코딩을 줄여 씬 호출 오류방지를 위해 enum 사용
public enum SceneName
{
    TitleScene, //타이틀 씬
    FirstStage, //스테이지1 씬
    GameScene,  //스테이지2 씬
    ThirdStage, //스테이지3 씬
    ClearScene  //클리어 씬
}

/// <summary> 게임 전역에서 게임의 전반을 관리하는 매니저 클래스 </summary>
public class GameManager : MonoBehaviour
{
    // singleton pattern: 클래스 하나에 인스턴스가 하나만 생성되는 프래그래밍 패턴

    private static GameManager _instance = null;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("GameManager is null.");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this; //this : 현재 인스턴스를 가리키는 레퍼런스
        }
        else if(_instance != this)
        {
            Debug.Log("GameManager has another instance.");

            Destroy(gameObject); //현재 인스턴스 파괴(GameManger Object)
        }
        DontDestroyOnLoad(gameObject); //씬이 변경되어도 현재 게임 오브젝트를 유지시키는 메소드
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
         * 디바이스 성능에 따른 실행 결과의 차이 없애기
         * 어떤 성능의 컴퓨터에서 동작해도 같은 속도로 움직이도록 하는 처리
         * 스마트폰은 60, 고속의 PC는 300이 될 수 있는 디바이스 성능에 따라 게임 동작에 영향을 미칠 수 있다.
         * 프레임레이트를 60으로 고정
         */
        Application.targetFrameRate = 60;

        SoundManager.Instance.f_PlayBGM(SoundName.BGM_Title, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * 유니티에서 씬을 로드하는 것은 SceneManger.LoadScene() 메소드를 사용
     * 씬 이름이나 빌드 설정 인덱스를 파라미터로 전달하여 특정 씬을 로드할 수 있음
     * 씬 이름으로 로드 : SceneManger.LoadScene("MySceneName");
     * 빌드 설정 인덱스로 로드 : SceneManger.LoadScene(1); (두 번째 씬을 로드)
     * 마우스가 클릭된 것을 감지하면, SceneManger 클래스의 LoadScene 메소드를 사용해 게임 씬으로 전환
     */

    /// <summary> 매개변수로 받은 씬으로 이동하는 메소드 </summary>
    public void f_OpenScene(SceneName sceneName)
    {
        //SceneManager.LoadScene(SceneName);
        SceneManager.LoadScene(sceneName.ToString());
    }

    /*
     * GetActiveScene()은 현재 씬 이름을 문자열로 반환한다.
     * 그러나 씬 명칭 입력을 enum을 사용할 예정이므로,
     * 씬 이름을 enum으로 매핑해주는 메소드를 생성함
     */

    /// <summary> 현재 씬 명칭을 Enum과 매핑하는 메소드 </summary>
    public SceneName f_GetCurrentSceneEnum()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        //활성화된 string 타입 씬 이름을 enum에 정의된 이름일 경우 현재 씬 반환
        if (System.Enum.TryParse(sceneName, out SceneName currentScene))
        {
            return currentScene;
        }
        else
        {
            Debug.LogWarning($"씬 {sceneName}이 SceneName Enum에 존재하지 않습니다.");
        }

        return SceneName.TitleScene; //예외 사항이 발생시 타이틀화면으로 이동
    }

    /// <summary> 활성화된 씬 네임을 불러오는 메소드 </summary>
    public string f_GetSceneName() //활성화된 씬 이름을 불러와서 씬에 맞는 BGM 재생을 자동화 하기위함
    {
        string sSceneName = null;

        sSceneName = SceneManager.GetActiveScene().name;

        return sSceneName;
    }

}
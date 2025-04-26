/*
 * 플레이어의 몰입감을 향상시키기 위해 게임 내 배경음악(BGM)과 점프 효과음(SFX) 시스템을 구현한다.
 * 게임 플레이 중 자연스럽게 흐르는 음악과, 점프 액션마다 즉각적으로 반응하는 효과음을 추가하여 게임의 완성도를 높인다.
 * SoundManager 싱글톤을 제작하여 배경음악과 효과음을 전역 관리할 수 있는 구조를 마련한다.
 */
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /*
     * 직접적인 public 선언은 객체 지향의 철학과 맞지 않기에 get, set 사용하여 접근
     * set은 private set으로 지정하여 읽기전용으로 변경
     * SoundManager 클래스 내에선 set 사용가능 / 외부클래스 접근불가
     */

    /* [Soure와 Clip 이원화 이유]
     * 1. Source 없이 Clip만 등록한다면?
     * AudioClip 데이터만 들고 있게 된다.
     * 재생하려면 별도로 AudioSource를 추가하고 연결해야 하는 문제점 발생
     * 로직이 비효율적이고 복잡해지는 결과를 초래한다.
     * 2. Source + Clip 같이 관리하면?
     * Source가 이미 세팅되어 있기 때문에
     * 코드로 재생, 정지, 볼륨 조정을 모두 할 수 있다.
     */

    //[SerializeField]: private 접근 제한을 유지하며 인스펙터에 노출되어 Unity 편집기로 설정할 수 있음.
    [SerializeField] private AudioSource sourceGameStageBGM = null; //게임 스테이지 배경음악 소스
    [SerializeField] private AudioSource sourceJumpSFX = null;      //점프 효과음 소스
    
    [SerializeField] private AudioClip clipGameStageBGM = null; //게임 스테이지 배경음악 클립
    [SerializeField] private AudioClip clipJumpSFX = null;      //점프 효과음 클립          


    //프로퍼티(Property)는 속성이란 의미.
    //프로퍼티를 사용하게 되면, 속성 값을 반환하거나 새 값을 할당할 수 있다.

    /// <summary> 게임 스테이지 배경음악 소스 접근자 </summary>
    public AudioSource SourceGameStageBGM
    {
        get { return sourceGameStageBGM; }
        private set { sourceGameStageBGM = value; }
    }

    /// <summary> 점프 효과음 소스 접근자 </summary>
    public AudioSource SourceJumpSFX
    {
        get { return sourceJumpSFX; }
        private set { sourceJumpSFX = value; }
    }

    /// <summary> 게임 스테이지 배경음악 클립 접근자 </summary>
    public AudioClip ClipGameStageBGM
    {
        get { return clipGameStageBGM; }
        private set { clipGameStageBGM = value; }
    }

    /// <summary> 점프 효과음 클립 접근자 </summary>
    public AudioClip ClipJumpSFX
    {
        get { return clipJumpSFX; }
        private set { clipJumpSFX = value; }
    }


    // singleton pattern: 클래스 하나에 인스턴스가 하나만 생성되는 프래그래밍 패턴
    private static SoundManager _instance = null;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("GameManager is null.");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this; //this : 현재 인스턴스를 가리키는 레퍼런스
        }
        else if (_instance != this)
        {
            Debug.Log("SoundManager has another instance.");

            Destroy(gameObject); //현재 인스턴스 파괴(GameManger Object)
        }
        DontDestroyOnLoad(gameObject); //씬이 변경되어도 현재 게임 오브젝트를 유지시키는 메소드
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //f_PlayGameStageBGM(); //게임 배경음악 재생
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary> 게임 스테이지의 배경음악을 반복재생하는 메소드 </summary>
    public void f_PlayGameStageBGM()
    {
        if (SourceGameStageBGM != null && ClipGameStageBGM != null) //소스와 클립이 모두 존재하는 경우(not null)
        {
            SourceGameStageBGM.clip = ClipGameStageBGM;
            SourceGameStageBGM.loop = true; //반복 재생 true값
            SourceGameStageBGM.volume = 0.1f; //볼륨 10%
            SourceGameStageBGM.Play(); //재생
        }
    }

    /// <summary> 게임 스테이지의 배경음악 재생을 중단하는 메소드 </summary>
    public void f_StopGameStageBGM()
    {
        if(SourceGameStageBGM != null && SourceGameStageBGM.isPlaying)
        {
            SourceGameStageBGM.Stop();
        }
    }

    /// <summary> 점프 효과음을 재생하는 메소드 </summary>
    public void f_PlayJumpSFX()
    {
        if(SourceJumpSFX != null && ClipJumpSFX != null) //소스와 클립이 모두 존재하는 경우(not null)
        {
            SourceJumpSFX.volume = 0.1f; //볼륨 10%
            SourceJumpSFX.PlayOneShot(ClipJumpSFX); //PlayOneShot 메소드를 이용하여 한 번만 재생
        }
    }


}

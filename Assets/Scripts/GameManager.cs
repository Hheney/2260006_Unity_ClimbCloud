/*
 * ����, �ð�, �÷��̾� ���µ��� ��� �߰� �� �뷱�� ������ ����Ͽ� �̱��� ������ GameManger ����
 * ���� ��ũ��Ʈ���� ���� ����� �� ��Ҹ� �����Ͽ� �����ϱ� ����
 * ���� ��ü������ 5��Ģ�� �ϳ��� ���� å�� ��Ģ(Single Responsibility Principle)�� �ؼ��ϱ� ����
 */

using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement; //���� ��ȯ�ϱ� ���� ���Ŵ��� ����Ʈ

/*
 * �Ű������� ���� ������Ʈ�� SetActive, true false���� ������ �� �ִ� �޼ҵ�
 */
//public class NextSceneManager : MonoBehaviour
//{
//    public static void f_NextScene(GameObject gameObject, bool isActive, bool isClick, string sceneName)
//    {
//        Debug.Log($"������Ʈ ��Ī : {gameObject}");


//        gameObject.SetActive(isActive);

//        if(isClick)
//        {
//            SceneManager.LoadScene(sceneName);
//            return;
//        }
        
//    }
//}



/// <summary> ���� �������� ������ ������ �����ϴ� �Ŵ��� Ŭ���� </summary>
public class GameManager : MonoBehaviour
{
    // singleton pattern: Ŭ���� �ϳ��� �ν��Ͻ��� �ϳ��� �����Ǵ� �����׷��� ����

    private static GameManager _instance = null;

    //[SerializeField] private string nextSceneName;

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
            _instance = this; //this : ���� �ν��Ͻ��� ����Ű�� ���۷���
        }
        else if(_instance != this)
        {
            Debug.Log("GameManager has another instance.");

            Destroy(gameObject); //���� �ν��Ͻ� �ı�(GameManger Object)
        }
        DontDestroyOnLoad(gameObject); //���� ����Ǿ ���� ���� ������Ʈ�� ������Ű�� �޼ҵ�
    }

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

        SoundManager.Instance.f_PlayBGM(SoundName.BGM_Title, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * ����Ƽ���� ���� �ε��ϴ� ���� SceneManger.LoadScene() �޼ҵ带 ���
     * �� �̸��̳� ���� ���� �ε����� �Ķ���ͷ� �����Ͽ� Ư�� ���� �ε��� �� ����
     * �� �̸����� �ε� : SceneManger.LoadScene("MySceneName");
     * ���� ���� �ε����� �ε� : SceneManger.LoadScene(1); (�� ��° ���� �ε�)
     * ���콺�� Ŭ���� ���� �����ϸ�, SceneManger Ŭ������ LoadScene �޼ҵ带 ����� ���� ������ ��ȯ
     */

    //���� ��ũ��Ʈ���� ���� ����� ����Ǿ� GameManger���� �޼ҵ�ȭ

    /// <summary> Ÿ��Ʋ ȭ������ �̵��ϴ� �޼ҵ� </summary>
    public void f_OpenTitle() //Ÿ��Ʋ ȭ��
    {
        SceneManager.LoadScene("TitleScene");
    }

    /// <summary> 2��° �������������� �̵��ϴ� �޼ҵ� </summary>
    public void f_GameStart() //���� ����
    {
        SceneManager.LoadScene("GameScene");
    }

    /// <summary> ���� �޴������� �̵��ϴ� �޼ҵ� </summary>
    public void f_OpenMainMenu()
    {
        //SceneManager.LoadScene("");
    }

    /// <summary> �Ű������� ���� ������ �̵��ϴ� �޼ҵ� </summary>
    public void f_OpenScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    /// <summary> ���������� ������ �� �ִ� ������ �̵��ϴ� �޼ҵ� </summary>
    public void f_OpenStageSelect()
    {
        //SceneManager.LoadScene("");
    }

    /// <summary> ���ӿ��������� �̵��ϴ� �޼ҵ� </summary>
    public void f_GameOver()
    {
        //SceneManager.LoadScene("");
    }

    /// <summary> ������ ������ϴ� �޼ҵ� </summary>
    public void f_RestartGame() //���� �����
    {
        SceneManager.LoadScene("TitleScene");

        //SoundManager.Instance.f_StopBGM(SoundName.BGM_StageBGM2);
        SoundManager.Instance.f_PlayBGM(SoundName.BGM_StageBGM1, 0.1f); //��������1 ������� 10% �������� ���
    }

    public void f_OpenClearGame() //���� Ŭ���� ��ȯ
    {
        SceneManager.LoadScene("ClearScene");

        //SoundManager.Instance.f_StopBGM(SoundName.BGM_StageBGM1); //��������1 ������� ��� ����
        SoundManager.Instance.f_PlayBGM(SoundName.BGM_StageBGM2, 0.1f);
    }

    //Ȱ��ȭ�� �� �̸��� �ҷ��ͼ� ���� �´� BGM ����� �ڵ�ȭ �ϱ�����(�̿ϼ�)
    /// <summary> Ȱ��ȭ�� �� ������ �ҷ����� �޼ҵ� </summary>
    public string f_GetSceneName()
    {
        string sSceneName = null;

        sSceneName = SceneManager.GetActiveScene().name;

        return sSceneName;
    }

}

/*
 * ����, �ð�, �÷��̾� ���µ��� ��� �߰� �� �뷱�� ������ ����Ͽ� �̱��� ������ GameManger ����
 * ���� ��ũ��Ʈ���� ���� ����� �� ��Ҹ� �����Ͽ� �����ϱ� ����
 * ���� ��ü������ 5��Ģ�� �ϳ��� ���� å�� ��Ģ(Single Responsibility Principle)�� �ؼ��ϱ� ����
 */
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement; //���� ��ȯ�ϱ� ���� ���Ŵ��� ����Ʈ


//�� �̸��� �����Է��ϴ� ���ڿ� �ϵ��ڵ��� �ٿ� �� ȣ�� ���������� ���� enum ���
public enum SceneName
{
    TitleScene, //Ÿ��Ʋ ��
    FirstStage, //��������1 ��
    GameScene,  //��������2 ��
    ThirdStage, //��������3 ��
    ClearScene  //Ŭ���� ��
}

/// <summary> ���� �������� ������ ������ �����ϴ� �Ŵ��� Ŭ���� </summary>
public class GameManager : MonoBehaviour
{
    // singleton pattern: Ŭ���� �ϳ��� �ν��Ͻ��� �ϳ��� �����Ǵ� �����׷��� ����

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

    /// <summary> �Ű������� ���� ������ �̵��ϴ� �޼ҵ� </summary>
    public void f_OpenScene(SceneName sceneName)
    {
        //SceneManager.LoadScene(SceneName);
        SceneManager.LoadScene(sceneName.ToString());
    }

    /*
     * GetActiveScene()�� ���� �� �̸��� ���ڿ��� ��ȯ�Ѵ�.
     * �׷��� �� ��Ī �Է��� enum�� ����� �����̹Ƿ�,
     * �� �̸��� enum���� �������ִ� �޼ҵ带 ������
     */

    /// <summary> ���� �� ��Ī�� Enum�� �����ϴ� �޼ҵ� </summary>
    public SceneName f_GetCurrentSceneEnum()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        //Ȱ��ȭ�� string Ÿ�� �� �̸��� enum�� ���ǵ� �̸��� ��� ���� �� ��ȯ
        if (System.Enum.TryParse(sceneName, out SceneName currentScene))
        {
            return currentScene;
        }
        else
        {
            Debug.LogWarning($"�� {sceneName}�� SceneName Enum�� �������� �ʽ��ϴ�.");
        }

        return SceneName.TitleScene; //���� ������ �߻��� Ÿ��Ʋȭ������ �̵�
    }

    /// <summary> Ȱ��ȭ�� �� ������ �ҷ����� �޼ҵ� </summary>
    public string f_GetSceneName() //Ȱ��ȭ�� �� �̸��� �ҷ��ͼ� ���� �´� BGM ����� �ڵ�ȭ �ϱ�����
    {
        string sSceneName = null;

        sSceneName = SceneManager.GetActiveScene().name;

        return sSceneName;
    }

}
/*
 * �÷��̾��� ���԰��� ����Ű�� ���� ���� �� �������(BGM)�� ���� ȿ����(SFX) �ý����� �����Ѵ�.
 * ���� �÷��� �� �ڿ������� �帣�� ���ǰ�, ���� �׼Ǹ��� �ﰢ������ �����ϴ� ȿ������ �߰��Ͽ� ������ �ϼ����� ���δ�.
 * SoundManager �̱����� �����Ͽ� ������ǰ� ȿ������ ���� ������ �� �ִ� ������ �����Ѵ�.
 */
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /*
     * �������� public ������ ��ü ������ ö�а� ���� �ʱ⿡ get, set ����Ͽ� ����
     * set�� private set���� �����Ͽ� �б��������� ����
     * SoundManager Ŭ���� ������ set ��밡�� / �ܺ�Ŭ���� ���ٺҰ�
     */

    /* [Soure�� Clip �̿�ȭ ����]
     * 1. Source ���� Clip�� ����Ѵٸ�?
     * AudioClip �����͸� ��� �ְ� �ȴ�.
     * ����Ϸ��� ������ AudioSource�� �߰��ϰ� �����ؾ� �ϴ� ������ �߻�
     * ������ ��ȿ�����̰� ���������� ����� �ʷ��Ѵ�.
     * 2. Source + Clip ���� �����ϸ�?
     * Source�� �̹� ���õǾ� �ֱ� ������
     * �ڵ�� ���, ����, ���� ������ ��� �� �� �ִ�.
     */

    //[SerializeField]: private ���� ������ �����ϸ� �ν����Ϳ� ����Ǿ� Unity ������� ������ �� ����.
    [SerializeField] private AudioSource sourceGameStageBGM = null; //���� �������� ������� �ҽ�
    [SerializeField] private AudioSource sourceJumpSFX = null;      //���� ȿ���� �ҽ�
    
    [SerializeField] private AudioClip clipGameStageBGM = null; //���� �������� ������� Ŭ��
    [SerializeField] private AudioClip clipJumpSFX = null;      //���� ȿ���� Ŭ��          


    //������Ƽ(Property)�� �Ӽ��̶� �ǹ�.
    //������Ƽ�� ����ϰ� �Ǹ�, �Ӽ� ���� ��ȯ�ϰų� �� ���� �Ҵ��� �� �ִ�.

    /// <summary> ���� �������� ������� �ҽ� ������ </summary>
    public AudioSource SourceGameStageBGM
    {
        get { return sourceGameStageBGM; }
        private set { sourceGameStageBGM = value; }
    }

    /// <summary> ���� ȿ���� �ҽ� ������ </summary>
    public AudioSource SourceJumpSFX
    {
        get { return sourceJumpSFX; }
        private set { sourceJumpSFX = value; }
    }

    /// <summary> ���� �������� ������� Ŭ�� ������ </summary>
    public AudioClip ClipGameStageBGM
    {
        get { return clipGameStageBGM; }
        private set { clipGameStageBGM = value; }
    }

    /// <summary> ���� ȿ���� Ŭ�� ������ </summary>
    public AudioClip ClipJumpSFX
    {
        get { return clipJumpSFX; }
        private set { clipJumpSFX = value; }
    }


    // singleton pattern: Ŭ���� �ϳ��� �ν��Ͻ��� �ϳ��� �����Ǵ� �����׷��� ����
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
            _instance = this; //this : ���� �ν��Ͻ��� ����Ű�� ���۷���
        }
        else if (_instance != this)
        {
            Debug.Log("SoundManager has another instance.");

            Destroy(gameObject); //���� �ν��Ͻ� �ı�(GameManger Object)
        }
        DontDestroyOnLoad(gameObject); //���� ����Ǿ ���� ���� ������Ʈ�� ������Ű�� �޼ҵ�
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //f_PlayGameStageBGM(); //���� ������� ���
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary> ���� ���������� ��������� �ݺ�����ϴ� �޼ҵ� </summary>
    public void f_PlayGameStageBGM()
    {
        if (SourceGameStageBGM != null && ClipGameStageBGM != null) //�ҽ��� Ŭ���� ��� �����ϴ� ���(not null)
        {
            SourceGameStageBGM.clip = ClipGameStageBGM;
            SourceGameStageBGM.loop = true; //�ݺ� ��� true��
            SourceGameStageBGM.volume = 0.1f; //���� 10%
            SourceGameStageBGM.Play(); //���
        }
    }

    /// <summary> ���� ���������� ������� ����� �ߴ��ϴ� �޼ҵ� </summary>
    public void f_StopGameStageBGM()
    {
        if(SourceGameStageBGM != null && SourceGameStageBGM.isPlaying)
        {
            SourceGameStageBGM.Stop();
        }
    }

    /// <summary> ���� ȿ������ ����ϴ� �޼ҵ� </summary>
    public void f_PlayJumpSFX()
    {
        if(SourceJumpSFX != null && ClipJumpSFX != null) //�ҽ��� Ŭ���� ��� �����ϴ� ���(not null)
        {
            SourceJumpSFX.volume = 0.1f; //���� 10%
            SourceJumpSFX.PlayOneShot(ClipJumpSFX); //PlayOneShot �޼ҵ带 �̿��Ͽ� �� ���� ���
        }
    }


}

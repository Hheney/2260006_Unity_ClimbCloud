using UnityEngine;

/*
 * �߻� Ŭ����(abstract class) ���
 * �⺻ ����� �����ϰ�, �ڽ� Ŭ�������� ��ӹ޾� ��ü���� ����� ������ �� �ֵ��� ��
 * ��� ������ ���� Ŭ�����̴�.
 * 3���� ���������� ���� ���·� �ߺ��ǹǷ�, BaseStageController�� �����Ͽ� ��ӹ޾� �ߺ��� ������
 * ���ο� ���������� �߻��Ͽ��� Ȯ�忡 �����ϵ��� ������
 * 
 * BaseStageController
 *  - FirstStageController
 *  - GameSceneController
 *  - ThirdStageController
 */
public abstract class BaseStageController : MonoBehaviour
{
    [SerializeField] protected SceneName nextScene; //Inspector���� ���� ���� ������ �� �ֵ��� ��

    //virtual Ű���� : �ڽ� Ŭ�������� ���������� ������(override) ������ �޼ҵ�
    //�ڽ�Ŭ�������� �������̵����� ���� ��� �⺻������ �Ʒ��� ���� ���°� �״�� ������
    public virtual void f_ContinueButton()
    {
        GameManager.Instance.f_OpenScene(nextScene); //SceneName�� enum���� �����Ǿ� �����Ƿ�, Inspector���� ���� ����
    }
}

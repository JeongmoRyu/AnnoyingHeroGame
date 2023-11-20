using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectInfo4
{
    public GameObject goPrefab;
    public int count;
    public Transform tfPoolParent;

}

public class ObjectPool4 : MonoBehaviour
{
    [SerializeField] ObjectInfo4[] objectInfo = null;

    // ObjectPool을 언제 어디서든 쉽게 가져다 쓰고 반납할 수가 있어야함
    // 따라서 이를 공유 자원으로 만들자
    // 공유자원 instance를 통해 어디서든 public 변수, 함수에 접근이 가능!
    // ObjectPool.instance로 public이라고 된 것들 전부 쓸 수 있다
    public static ObjectPool4 instance;

    // noteQueue가 하나의 Pool이 될거
    // 여기서 이제 노트를 가져다 쓰는거
    public Queue<GameObject> noteQueue = new Queue<GameObject>();

    void Start()
    {
        // 위 상태로만 두면 값이 없는 상태니까, 자기 자신으로 두자
        instance = this;

        // 리턴시킨 값을 noteQueue에 넣어줄거
        // noteQueue에 들어갈 오브젝트는 배열 첫번째로 넣어주자
        noteQueue = InsertQueue(objectInfo[0]);

        // 생성 파괴가 자주 이뤄지는 객체가 있다?
        // => 그러면 첫번째 배열, 두번째 배열을 또 만들어서 각각 다른 큐에 넣어주면 된다
    }
    
    Queue<GameObject> InsertQueue(ObjectInfo4 p_objectInfo)
    {
        Queue<GameObject> t_queue = new Queue<GameObject>();
        for (int i = 0; i < p_objectInfo.count; i++)
        {
            // 노트를(프리펩을) 생성시켜줘야함
            // 적당한 위치에 넣어주면 될듯, 어차피 비활성화 시킬거라 게임에선 보이지 않으니
            GameObject t_clone = Instantiate(p_objectInfo.goPrefab, transform.position, Quaternion.identity);
            t_clone.SetActive(false); // 생성했으니 바로 비활성화

            // 부모를 설정해줄거
            // 기존에 설정했던 노트 같은 경우에는 노트 매니저 스크립트가 붙어있는 객체가 부모였다
            // 그래서 부모 객체가 존재한다면, 그 객체를 부모로 삼아주자
            if (p_objectInfo.tfPoolParent != null)
                t_clone.transform.SetParent(p_objectInfo.tfPoolParent);
            else
                t_clone.transform.SetParent(this.transform); // 부모 객체가 null 값이라면, 이 스크립트가 붙어있는 객체를 부모로

            // 반복문이 돌고나면 큐에는 카운트 개수 만큼의 객체가 들어있을거
            t_queue.Enqueue(t_clone);
        }
        return t_queue;
    }
}

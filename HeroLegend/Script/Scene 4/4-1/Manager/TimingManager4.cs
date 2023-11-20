using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager4 : MonoBehaviour
{

    // 생성된 노트를 담는 List => 판정범위에 있는지 모든 노트를 비교해야 함
    public List<GameObject> boxNoteList = new List<GameObject>();

    int[] judgementRecord = new int[5];

    [SerializeField] Transform Center = null;            // 판정 범위의 중심을 알려주는 변수
    [SerializeField] RectTransform[] timingRect = null;  // 다양한 판정 범위 (Perfect, Cool, Good, Bad)
    Vector2[] timingBoxs = null;                         // 판정 범위의 최소값(x), 최대값(y)
                                                         // 여기에 RectTransform의 값을 정리해서 넣어줄거

    EffectManager4 theEffect;
    ScoreManager4 theScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        theEffect = FindObjectOfType<EffectManager4>();
        theScoreManager = FindObjectOfType<ScoreManager4>();

        // 타이밍 박스 설정
        timingBoxs = new Vector2[timingRect.Length];
        for (int i = 0; i < timingRect.Length; i++)
        {
            // 각각의 판정 범위의 최소값과 최대값
            // 0번째 Perfect가 판정 범위가 가장 좁고, 3번째 Bad가 가장 넓겠다
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,
                              Center.localPosition.x + timingRect[i].rect.width / 2);
        }
    }

    public void CheckTiming()
    {
        theEffect.SpaceButtonDownEffect();

        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.x;

            for (int x = 0; x < timingBoxs.Length; x++)
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    boxNoteList[i].GetComponent<Note4>().HideNote();
                    boxNoteList.RemoveAt(i);

                    // 이펙트 연출
                    if (x < timingBoxs.Length - 1) // bad 판정이 아닐 때만
                    {
                        theEffect.NoteHitEffect();
                    }
                    judgementRecord[x]++;          // 판정 기록
                    theEffect.JudgementEffect(x);  // 판정 연출

                    // 점수 증가
                    theScoreManager.IncreaseScore(x);

                    return;
                }
            }
        }

        theScoreManager.IncreaseScore(timingBoxs.Length);
        theEffect.JudgementEffect(timingBoxs.Length);
        theEffect.LegBossAttackEffect();
        MissRecord();
    }

    public int[] GetJudgementRecord()
    {
        return judgementRecord;
    }

    public void MissRecord()
    {
        judgementRecord[4]++;   // 판정 기록
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager4 : MonoBehaviour
{
    // 분당 비트 수(분당 노트 수)
    public int bpm = 0;

    public GameObject gameStartText;

    // 리듬 게임에서는 오차가 적어야 하므로 float 대신 double
    double currentTime = 0d;

    AudioSource startCountdownAudio;

    // bool noteActive = true;
    bool noteActive = false;

    [SerializeField] Transform tfNoteAppear = null;

    TimingManager4 theTimingManager;
    EffectManager4 theEffectManager;
    ScoreManager4 theScoreManager;

    private void Start()
    {
        theEffectManager = FindObjectOfType<EffectManager4>();
        theTimingManager = GetComponent<TimingManager4>();
        theScoreManager = FindObjectOfType<ScoreManager4>();

        startCountdownAudio = GetComponent<AudioSource>();
        startCountdownAudio.Play();

        Invoke("ActivateGameStartText", 2.7f);
        Invoke("activateNote", 4f);
    }

    void activateNote()
    {
        noteActive = true;
    }

    void ActivateGameStartText()
    {
        gameStartText.SetActive(true);
        Invoke("DeactivateGameStartText", 1f);
    }

    void DeactivateGameStartText()
    {
        gameStartText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (noteActive)
        {
            currentTime += Time.deltaTime;

            // 60(double) / bpm => 1비트 당 시간
            if (currentTime >= 30d / bpm)
            {
                if (Random.value < 0.4)
                {
                    GameObject t_note = ObjectPool4.instance.noteQueue.Dequeue();
                    t_note.transform.position = tfNoteAppear.position;
                    t_note.SetActive(true);
                    t_note.transform.localScale = new Vector3(1, 1, 1);
                    theTimingManager.boxNoteList.Add(t_note);
                }

                // 프레임 단위로 업데이트 하기에 0.51005xx 뭐 이런 식으로 오차가 생김
                // 근데 이를 그냥 0으로 초기화 해버리면 그 오차가 누적되서 나중에는 음이 안맞고 그럴 수 있다
                // 그래서 그것까지 고려해서 다음 노트는 오차 만큼 더 빨리 나오는 식으로 조정
                currentTime -= 30d / bpm;
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (collision.GetComponent<Note4>().GetNoteFlag())
            {
                theTimingManager.MissRecord();
                theEffectManager.JudgementEffect(4);
                theEffectManager.LegBossAttackEffect();
                theScoreManager.IncreaseScore(4);
            }
            theTimingManager.boxNoteList.Remove(collision.gameObject);

            ObjectPool4.instance.noteQueue.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }

    public void RemoveNote()
    {
        noteActive = false;

        for (int i = 0; i < theTimingManager.boxNoteList.Count; i++)
        {
            theTimingManager.boxNoteList[i].SetActive(false);
            ObjectPool4.instance.noteQueue.Enqueue(theTimingManager.boxNoteList[i]);
        }
    }
}

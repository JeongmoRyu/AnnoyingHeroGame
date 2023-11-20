using TMPro;
using UnityEngine;

public sealed class ScoreCounter5 : MonoBehaviour
{
    public static ScoreCounter5 Instance { get; private set; }
    public GameObject Board;
    public AudioSource monsterSound;

    private int _score;

    public int Score
    {
        get => _score;

        set
        {
            if (_score == value) return;

            _score = value;

            scoreText.SetText($"{_score}");

            if (_score > 0 && (_score / 100) % 2 == 1)
            {
                Board.SetActive(true);
            }

            else if (_score > 0 && (_score / 50) % 2 == 0)
            {
                Board.SetActive(false);
            }

            if ((_score - 50) % 100 == 0)
            {
                EnemyAction51.Instance.AttackonTitan();
                EnemyAction52.Instance.AttackonTitan();
            }

            if (_score >= 200)
            {
                EnemyAction51.Instance.TriggerSkilling();
                EnemyAction52.Instance.TriggerSkilling();
                monsterSound.Play();
                GameObject.FindObjectOfType<PlayerMove5>().CharacterKilled();
            }
        }
    }

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake() => Instance = this;
}

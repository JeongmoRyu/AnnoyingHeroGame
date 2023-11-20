using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public sealed class Board5 : MonoBehaviour
{
    public static Board5 Instance { get; private set; }

    public Row5[] rows;
    public Tile5[,] Tiles { get; private set; }

    public int Width => Tiles.GetLength(0);
    public int Height => Tiles.GetLength(1);

    public AudioSource selectSound;
    public AudioSource swapSound;
    public AudioSource popSound;

    private Tile5 _selectedTile1;
    private Tile5 _selectedTile2;

    private readonly List<Tile5> _selection = new List<Tile5>();

    private const float TweenDuration = 0.2f; // 타일 교환 속도
    private bool isSwapping = false; // 교환 중인지 여부


    private void Awake() => Instance = this;

    private void Start()
    {
        Tiles = new Tile5[rows.Max(row => row.tiles.Length), rows.Length];

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var tile = rows[y].tiles[x];

                tile.x = x;
                tile.y = y;

                Tiles[x, y] = rows[y].tiles[x];
                tile.Item = ItemDatabase5.Items[Random.Range(0, ItemDatabase5.Items.Length)];
            }
        }

        /* 타일 섞기 버튼[S] */
        var shuffleButton = GameObject.Find("ShuffleButton").GetComponent<Button>();
        shuffleButton.onClick.AddListener(ShuffleTiles);
    }

    public void ShuffleTiles()
    {
        List<Tile5> allTiles = new List<Tile5>();
        List<Item5> allItems = new List<Item5>();

        // 모든 타일과 아이템을 리스트에 추가
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                allTiles.Add(Tiles[x, y]);
                allItems.Add(Tiles[x, y].Item);
            }
        }

        // 아이템 리스트를 랜덤하게 섞음
        for (int i = 0; i < allItems.Count; i++)
        {
            Item5 temp = allItems[i];
            int randomIndex = Random.Range(i, allItems.Count);
            allItems[i] = allItems[randomIndex];
            allItems[randomIndex] = temp;
        }

        // 각 타일에 랜덤하게 섞인 아이템을 할당
        for (int i = 0; i < allTiles.Count; i++)
        {
            allTiles[i].Item = allItems[i];
        }
    }
    /* 타일 섞기 버튼[E] */

    public async void Select(Tile5 tile)
    {

        if (isSwapping) return;

        //if (!_selection.Contains(tile)) _selection.Add(tile);

        /* 선택된 타일 상호작용 [S] */
        if (_selection.Count > 0 && _selection[0] != tile)
        {
            _selection[0].icon.transform.localScale = Vector3.one;
            selectSound.Play();
        }

        if (!_selection.Contains(tile))
        {
            _selection.Add(tile);
            // 선택된 타일의 크기를 줄임
            tile.icon.transform.localScale = Vector3.one * 0.8f;
        }
        /* 선택된 타일 상호작용 [E] */

        // 두 개의 타일이 선택되었는가?
        if (_selection.Count < 2) return;

        // 첫 번째 타일과 두 번째 타일이 인접해 있는지 확인
        if (!IsAdjacent(_selection[0], _selection[1]))
        {
            Debug.Log("Tiles are not adjacent.");
            _selection.Clear();
            return;
        }

        Debug.Log($"Selected tiles at ({_selection[0].x}, {_selection[0].y}) ({_selection[1].x}, {_selection[1].y})");

        isSwapping = true;

        await Swap(_selection[0], _selection[1]);

        // 타일 교환 후 원래 크기로 복귀
        _selection[0].icon.transform.localScale = Vector3.one;
        _selection[1].icon.transform.localScale = Vector3.one;

        if (CanPop())
        {
            Pop();
        }
        else
        {
            await Swap(_selection[0], _selection[1]);
        }

        isSwapping = false;

        _selection.Clear();
    }

    // 인접한 타일인지 확인하는 메서드
    private bool IsAdjacent(Tile5 tile1, Tile5 tile2)
    {
        return (tile1.x == tile2.x && Mathf.Abs(tile1.y - tile2.y) == 1) ||
               (tile1.y == tile2.y && Mathf.Abs(tile1.x - tile2.x) == 1);
    }

    public async Task Swap(Tile5 tile1, Tile5 tile2)
    {
        var icon1 = tile1.icon;
        var icon2 = tile2.icon;

        var icon1Transform = icon1.transform;
        var icon2Transform = icon2.transform;

        var sequence = DOTween.Sequence();

        sequence.Join(icon1Transform.DOMove(icon2Transform.position, TweenDuration))
                .Join(icon2Transform.DOMove(icon1Transform.position, TweenDuration));

        await sequence.Play().AsyncWaitForCompletion();

        icon1Transform.SetParent(tile2.transform);
        icon2Transform.SetParent(tile1.transform);

        tile1.icon = icon2;
        tile2.icon = icon1;

        var tile1Item = tile1.Item;

        tile1.Item = tile2.Item;
        tile2.Item = tile1Item;

        swapSound.Play();
    }

    private bool CanPop()
    {
        for (var y = 0; y < Height; y++)
            for (var x = 0; x < Width; x++)
                if (Tiles[x, y].GetConnectedTiles().Skip(1).Count() >= 2)
                    return true;
        return false;
    }

    private async void Pop()
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var tile = Tiles[x, y];

                var connectedTiles = tile.GetConnectedTiles();

                if (connectedTiles.Skip(1).Count() < 2) continue;

                var deflateSequence = DOTween.Sequence();

                foreach (var connectedTile in connectedTiles) deflateSequence.Join(connectedTile.icon.transform.DOScale(Vector3.zero, TweenDuration));

                await deflateSequence.Play().AsyncWaitForCompletion();

                ScoreCounter5.Instance.Score += tile.Item.value * connectedTiles.Count;

                var inflateSequence = DOTween.Sequence();

                foreach (var connectedTile in connectedTiles)
                {
                    connectedTile.Item = ItemDatabase5.Items[Random.Range(0, ItemDatabase5.Items.Length)];

                    inflateSequence.Join(connectedTile.icon.transform.DOScale(Vector3.one, TweenDuration));
                }

                await inflateSequence.Play().AsyncWaitForCompletion();

                x = 0;
                y = 0;
            }
        }
        popSound.Play();
    }

    public void ResetTiles()
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var tile = Tiles[x, y];
                tile.Item = ItemDatabase5.Items[Random.Range(0, ItemDatabase5.Items.Length)];
            }
        }
    }

    /* 새로운 3 match Item [S] */
    //public void UpdateAllTiles()
    //{
    //    for (int x = 0; x < Width; x++)
    //    {
    //        for (int y = 0; y < Height; y++)
    //        {
    //            Tiles[x, y].Item = ItemDatabase5.Items[Random.Range(0, ItemDatabase5.Items.Length)];
    //        }
    //    }
    //}
    /* 새로운 3 match Item [E] */
}
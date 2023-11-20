using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Tile5 : MonoBehaviour
{
    public int x;
    public int y;

    public Item5 _item;

    public Item5 Item
    {
        get => _item;
        set
        {
            if (_item == value) return;

            _item = value;

            icon.sprite = _item.sprite;
        }
    }
    public Image icon;

    public Button button;

    public Tile5 Left => x > 0 ? Board5.Instance.Tiles[x - 1, y] : null;
    public Tile5 Top => y > 0 ? Board5.Instance.Tiles[x, y - 1] : null;
    public Tile5 Right => x < Board5.Instance.Width - 1 ? Board5.Instance.Tiles[x + 1, y] : null;
    public Tile5 Bottom => y < Board5.Instance.Height - 1 ? Board5.Instance.Tiles[x, y + 1] : null;

    public Tile5[] Neighbours => new[] {
        Left,
        Top,
        Right,
        Bottom
    };

    private void Start() => button.onClick.AddListener(() => Board5.Instance.Select(this));

    public List<Tile5> GetConnectedTiles(List<Tile5> exclude = null)
    {
        var result = new List<Tile5> { this, };

        if (exclude == null)
        {
            exclude = new List<Tile5> { this, };
        }
        else
        {
            exclude.Add(this);
        }

        foreach (var neighbour in Neighbours)
        {
            if (neighbour == null || exclude.Contains(neighbour) || neighbour.Item != Item) continue;

            result.AddRange(neighbour.GetConnectedTiles(exclude));
        }

        return result;
    }
}
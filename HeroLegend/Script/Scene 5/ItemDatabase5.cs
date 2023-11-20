using UnityEngine;

public static class ItemDatabase5
{
    public static Item5[] Items { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Intialize() => Items = Resources.LoadAll<Item5>("Items/");

    /* 새로운 3 match Item [S] */
    //private static void Initialize() => LoadItems("Items 1/");

    //public static void LoadItems(string path)
    //{
    //    Items = Resources.LoadAll<Item5>(path);

    //}
    /* 새로운 3 match Item [E] */
}
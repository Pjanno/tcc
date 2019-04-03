using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wrapper
{
    public List<id_item> iventario;
}

[System.Serializable]
public class id_item
{
    public int id;
    public List<Item> item;
    public int quantidade;

    public void CriaObjetoDoJson(string json)
    {
        Wrapper objeto = JsonUtility.FromJson<Wrapper>(json);
    }
}

[System.Serializable]
public class Item
{
    public int id_item;
    public string nome_item;
}

using DefaultNamespace;
using UnityEngine;

/// <summary>
/// 这是一个桥接类
/// </summary>
public class Main : MonoBehaviour
{
    private Game game;

    void Awake()
    {
        var ground=GameObject.Find("Ground");
        ViewFactory.init();
        game = new Game(ground);
    }

    void Start()
    {
        game.Start();
    }

    void Update()
    {
        game.Update();
    }
    
}
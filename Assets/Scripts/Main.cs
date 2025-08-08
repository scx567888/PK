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
        ViewFactory.init();
        game = new Game();
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
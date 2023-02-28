using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerCursorInstaller : MonoInstaller
{
    [SerializeField] private GameObject _playerCursorOwner;
    
    public override void InstallBindings()
    {
        Container.Bind<PlayerCursor>().FromComponentOn(_playerCursorOwner).AsSingle();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private GameObject _playerInventoryOwner;

    public override void InstallBindings()
    {
        Container.Bind<PlayerInventory>().FromComponentOn(_playerInventoryOwner).AsSingle();
    }
}

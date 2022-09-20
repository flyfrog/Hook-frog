using Controls;
using Managers;
using Player;
using ScriptableObjectScript;
using UI;
using UnityEngine;
using Zenject;

public class Monoinstaller : MonoInstaller
{
    [SerializeField] private PlayerSettingsSO _playerSettingsSO;

    public override void InstallBindings()
    {
        //Scriptable object
        Container.Bind<PlayerSettingsSO>().FromInstance(_playerSettingsSO).AsSingle().NonLazy();


        //Normal class
        Container.Bind<PauseManager>().AsSingle().NonLazy();
        Container.Bind<GameOverManager>().AsSingle().NonLazy();
        Container.Bind<RestartManager>().AsSingle().NonLazy();
        Container.Bind<MenuUIController>().AsSingle().NonLazy();
        Container.Bind<WinManager>().AsSingle().NonLazy();
  
        
        //intarface realize
        Container.BindInterfacesAndSelfTo<PlayerMoveController>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<InputManager>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ProgressManager>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<JumpController>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ClickController>().AsSingle().NonLazy();
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainGameInstaller : MonoInstaller
{
    [SerializeField] private GameObject _bulletsContainer;
    [SerializeField] private GameObject _enemiesContainer;
    [SerializeField] private SpaceFighter.InputEvents _events;

    public override void InstallBindings()
    {
        Container.Bind<GameObject>().WithId("BulletsContainer").FromInstance(_bulletsContainer);

        Container.Bind<GameObject>().WithId("EnemiesContainer").FromInstance(_enemiesContainer);

        Container.Bind<SpaceFighter.InputEvents>().WithId("SpaceFighterEvents").FromInstance(_events);

        Container.Bind<GameObject>().WithId("ParentGameObject").FromMethod(SetParent);
    }

    private GameObject SetParent(InjectContext context)
    {
        if (context.ObjectInstance is Component)
        {
            return ((Component)context.ObjectInstance).transform.parent.gameObject;
        }
        return null;
    }
}
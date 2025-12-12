using System;
using System.Collections.Generic;
using UnityEngine;

namespace ApplicationEngine.GameCycle
{
    public sealed class GameCycleManager : MonoBehaviour
    {
        public GameState GameState { get; private set; }
        
        private readonly List<IInitializable> _initializableListeners = new();
        private readonly List<IStartable> _startableListeners = new();
        private readonly List<IUpdatable> _updatableListeners = new();
        private readonly List<IFixedUpdatable> _fixedUpdatableListeners = new();
        private readonly List<ILateUpdatable> _lateUpdatableListeners = new();
        private readonly List<IFinishable> _finishableListeners = new();

        private void Awake()
        {
            OnInitialize();
        }

        private void Start()
        {
            OnStart();
        }

        public void OnInitialize()
        {
            if (GameState != GameState.None) 
                return;

            for (int i = 0; i < _initializableListeners.Count; i++)
            {
                _initializableListeners[i].OnInitialize();
            }
            
            GameState = GameState.Initialized;
        }
        
        public void OnStart()
        {
            if (GameState != GameState.Initialized)
                return;

            for (int i = 0; i < _startableListeners.Count; i++)
            {
                _startableListeners[i].OnStart();
            }
            
            GameState = GameState.Active;
        }
        
        private void Update()
        {
            if (GameState == GameState.Active)
            {
                for (int i = 0; i < _updatableListeners.Count; i++)
                {
                    _updatableListeners[i].OnUpdate();
                }
            }
        }
        
        private void FixedUpdate()
        {
            if (GameState != GameState.Active)
                return;

            for (int i = 0; i < _fixedUpdatableListeners.Count; i++)
            {
                _fixedUpdatableListeners[i].OnFixedUpdate();
            }
        }
        
        private void LateUpdate()
        {
            if (GameState != GameState.Active)
                return;

            for (int i = 0; i < _lateUpdatableListeners.Count; i++)
            {
                _lateUpdatableListeners[i].OnLateUpdate();
            }
        }

        private void OnDestroy()
        {
            if (GameState == GameState.Finished)
                return;

            for (int i = 0; i < _finishableListeners.Count; i++)
            {
                _finishableListeners[i].OnFinish();
            }
            
            GameState = GameState.Finished;
        }
        
        public void AddListener(IGameListener listener)
        {
            if (listener is IInitializable initializable)
            {
                if (!_initializableListeners.Contains(initializable))
                {
                    if (GameState is GameState.Initialized or GameState.Active)
                        initializable.OnInitialize();
                    
                    _initializableListeners.Add(initializable);
                }
            }
            
            if (listener is IStartable startable)
            {
                if (!_startableListeners.Contains(startable))
                {
                    if (GameState == GameState.Active)
                        startable.OnStart();
                    
                    _startableListeners.Add(startable);
                }
            }
            
            if (listener is IUpdatable updatable)
            {
                if (!_updatableListeners.Contains(updatable))
                    _updatableListeners.Add(updatable);
            }

            if (listener is IFixedUpdatable fixedUpdatable)
            {
                if (!_fixedUpdatableListeners.Contains(fixedUpdatable))
                    _fixedUpdatableListeners.Add(fixedUpdatable);
            }

            if (listener is ILateUpdatable lateUpdatable)
            {
                if (!_lateUpdatableListeners.Contains(lateUpdatable))
                    _lateUpdatableListeners.Add(lateUpdatable);
            }

            if (listener is IFinishable finishable)
            {
                if (!_finishableListeners.Contains(finishable))
                    _finishableListeners.Add(finishable);
            }
        }
        
        public void RemoveListener(IGameListener listener)
        {
            if (listener is IInitializable initializable)
            {
                if (_initializableListeners.Contains(initializable))
                    _initializableListeners.Remove(initializable);
            }

            if (listener is IStartable startable)
            {
                if (_startableListeners.Contains(startable))
                    _startableListeners.Remove(startable);
            }
            
            if (listener is IUpdatable updatable)
            {
                if (_updatableListeners.Contains(updatable))
                    _updatableListeners.Remove(updatable);
            }

            if (listener is IFixedUpdatable fixedUpdatable)
            {
                if (_fixedUpdatableListeners.Contains(fixedUpdatable))
                    _fixedUpdatableListeners.Remove(fixedUpdatable);
            }

            if (listener is ILateUpdatable lateUpdatable)
            {
                if (_lateUpdatableListeners.Contains(lateUpdatable))
                    _lateUpdatableListeners.Remove(lateUpdatable);
            }

            if (listener is IFinishable finishable)
            {
                if (!_finishableListeners.Contains(finishable))
                    return;
                
                if (GameState != GameState.None)
                    finishable.OnFinish();
                    
                _finishableListeners.Remove(finishable);
            }
        }
    }
}
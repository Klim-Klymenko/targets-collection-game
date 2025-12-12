using System;
using UnityEngine;
using Zenject;

namespace Common.Physics
{
    internal abstract class EventReceiver<TOther, TCondition, TAction> : MonoBehaviour
    where TOther : class
    where TCondition : IFunction<TOther, bool>
    where TAction : IAction<TOther>
    {
        public event Action<TOther> OnEntered;
        public event Action<TOther> OnStood;
        public event Action<TOther> OnExited;

        [Header("Conditions")]
        
        [SerializeReference]
        private TCondition[] _enterConditions;

        [SerializeReference] 
        private TCondition[] _stayConditions;

        [SerializeReference]
        private TCondition[] _exitConditions;
        
        [Header("Actions")]
        
        [SerializeReference]
        private TAction[] _enterActions;
        
        [SerializeReference] 
        private TAction[] _exitActions;

        [SerializeReference] 
        private TAction[] _stayActions;
        
        [Header("Base Actions")]
        
        [SerializeReference]
        private IAction[] _enterBaseActions;

        [SerializeReference]
        private IAction[] _exitBaseActions;

        [SerializeReference]
        private IAction[] _stayBaseActions;

        [Inject]
        internal void Construct(DiContainer diContainer)
        {
            if (_enterActions != null)
            {
                for (int i = 0; i < _enterActions.Length; i++)
                {
                    diContainer.Inject(_enterActions[i]);
                }
            }
            
            if (_stayActions != null)
            {
                for (int i = 0; i < _stayActions.Length; i++)
                {
                    diContainer.Inject(_stayActions[i]);
                }
            }
            
            if (_exitActions != null)
            {
                for (int i = 0; i < _exitActions.Length; i++)
                {
                    diContainer.Inject(_exitActions[i]);
                }
            }
            
            if (_enterBaseActions != null)
            {
                for (int i = 0; i < _enterBaseActions.Length; i++)
                {
                    diContainer.Inject(_enterBaseActions[i]);
                }
            }
            
            if (_stayBaseActions != null)
            {
                for (int i = 0; i < _stayBaseActions.Length; i++)
                {
                    diContainer.Inject(_stayBaseActions[i]);
                }
            }
            
            if (_exitBaseActions != null)
            {
                for (int i = 0; i < _exitBaseActions.Length; i++)
                {
                    diContainer.Inject(_exitBaseActions[i]);
                }
            }
            
            if (_enterConditions != null)
            {
                for (int i = 0; i < _enterConditions.Length; i++)
                {
                    diContainer.Inject(_enterConditions[i]);
                }
            }
            
            if (_stayConditions != null)
            {
                for (int i = 0; i < _stayConditions.Length; i++)
                {
                    diContainer.Inject(_stayConditions[i]);
                }
            }
            
            if (_exitConditions != null)
            {
                for (int i = 0; i < _exitConditions.Length; i++)
                {
                    diContainer.Inject(_exitConditions[i]);
                }
            }
        }

        private protected void OnEnter(TOther other)
        {
            if (_enterConditions != null)
            {
                for (int i = 0, count = _enterConditions.Length; i < count; i++)
                {
                    if (!_enterConditions[i].Invoke(other))
                        return;
                }
            }

            if (_enterActions != null)
            {
                for (int i = 0, count = _enterActions.Length; i < count; i++)
                {
                    _enterActions[i].Invoke(other);
                }
            }
            
            if (_enterBaseActions != null)
            {
                for (int i = 0, count = _enterBaseActions.Length; i < count; i++)
                {
                    _enterBaseActions[i].Invoke();
                }
            }
            
            OnEntered?.Invoke(other);
        }

        private protected void OnStay(TOther other)
        {
            if (_stayConditions != null)
            {
                for (int i = 0, count = _stayConditions.Length; i < count; i++)
                {
                    if (!_stayConditions[i].Invoke(other))
                        return;
                }
            }

            if (_stayActions != null)
            {
                for (int i = 0, count = _stayActions.Length; i < count; i++)
                {
                    _stayActions[i].Invoke(other);
                }
            }
            
            if (_stayBaseActions != null)
            {
                for (int i = 0, count = _stayBaseActions.Length; i < count; i++)
                {
                    _stayBaseActions[i].Invoke();
                }
            }
            
            OnStood?.Invoke(other);
        }

        private protected void OnExit(TOther other)
        {
            if (_exitConditions != null)
            {
                for (int i = 0, count = _exitConditions.Length; i < count; i++)
                {
                    if (!_exitConditions[i].Invoke(other))
                        return;
                }
            }

            if (_exitActions != null)
            {
                for (int i = 0, count = _exitActions.Length; i < count; i++)
                {
                    _exitActions[i].Invoke(other);
                }
            }
            
            if (_exitBaseActions != null)
            {
                for (int i = 0, count = _exitBaseActions.Length; i < count; i++)
                {
                    _exitBaseActions[i].Invoke();
                }
            }
            
            OnExited?.Invoke(other);
        }
    }
}
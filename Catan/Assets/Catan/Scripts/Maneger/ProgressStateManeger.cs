using System;
using UniRx;
using UnityEngine;
using Catan.Scripts.Game;

namespace Catan.Scripts.Manager
{
    class ProgressStateManeger : MonoBehaviour
    {
        private ProgressState progressState = ProgressState.Title;

        public InitializationManeger initializationManeger;
        public void Update()
        {
            switch (progressState)
            {
                case ProgressState.Title:
                    progressState = ProgressState.Maching;
                    break;
                case ProgressState.Maching:
                    progressState = ProgressState.Initialization;
                    break;
                case ProgressState.Initialization:
                    initializationManeger.Excute();
                    progressState = ProgressState.Battle;
                    break;
                case ProgressState.Battle:
                    progressState = ProgressState.Finished;
                    break;
                case ProgressState.Finished:
                    progressState = ProgressState.Result;
                    break;
                case ProgressState.Result:
                    break;
            }
        }
    }
}
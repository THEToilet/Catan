using System;
using UniRx;
using UnityEngine;
using Catan.Scripts.Game;

namespace Catan.Scripts.Manager
{
    class ProgressStateManeger : MonoBehaviour
    {
        ProgressState progressState = ProgressState.Title;

        public void Update()
        {
            switch (progressState)
            {
                case ProgressState.Title:
                    break;
                case ProgressState.Maching:
                    break;
                case ProgressState.Initialization:
                    break;
                case ProgressState.Battle:
                    break;
                case ProgressState.Finished:
                    break;
                case ProgressState.Result:
                    break;
            }
        }
    }
}
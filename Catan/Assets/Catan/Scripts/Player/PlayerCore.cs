using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using Catan.Scripts.Player;
using Catan.Scripts.Manager;

namespace Catan.Scripts.Player
{

  public class PlayerCore : MonoBehaviour
  {
    [SerializeField] public PlayerId playerId;
    [SerializeField] private Belongings _belongings;
    public ReactiveProperty<int> playerScore = new ReactiveProperty<int>(0);

  }
}
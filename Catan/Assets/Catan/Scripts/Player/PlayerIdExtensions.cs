using UnityEngine;
using System;

namespace Catan.Scripts.Player
{
    public static class PlayerIdExtensions
    {
        public static Color ToColor(PlayerId id)
        {
            switch (id)
            {
                case PlayerId.Player1:
                    return Color.red;
                case PlayerId.Player2:
                    return Color.blue;
                case PlayerId.Player3:
                    return Color.green;
                case PlayerId.Player4:
                    return Color.yellow;
                default:
                    throw new ArgumentOutOfRangeException("id", id, null);
            }
        }
    }
}

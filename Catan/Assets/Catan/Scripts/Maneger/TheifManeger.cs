using Catan.Scripts.Generation;
using Catan.Scripts.Player;
using Catan.Scripts.Presenter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Manager
{

    public class TheifManeger : MonoBehaviour
    {
        public UIRestrictionPresenter uIRestrictionPresenter;
        public PointParentPresenter pointParentPresenter;
        public ToPleyerObject toPleyerObject;
        public bool isPlace = false;
        PlayerId[] playerIds = new PlayerId[] { PlayerId.Player1, PlayerId.Player1, PlayerId.Player3, PlayerId.Player4 };
        public void ReduceCard()
        {
            List<GameObject> deletePlayer = new List<GameObject>();
            // プレイヤーのカードが8枚以上だったら半分にする
            for (int i = 0; i < playerIds.Length; i++)
            {
                var p = toPleyerObject.ToPlayer(playerIds[i]);
                if (p.GetComponent<Belongings>().cards.Count >= 8)
                {
                    deletePlayer.Add(p);
                }


            }

            // 削除するカードを選ばせる
            for (int i = 0; i < deletePlayer.Count; i++)
            {
                var t = deletePlayer[i].GetComponent<Belongings>().cards.Count;
                while (deletePlayer[i].GetComponent<Belongings>().cards.Count <= t / 2)
                {
                    deletePlayer[i].GetComponent<Belongings>().cards.RemoveAt(deletePlayer[i].GetComponent<Belongings>().cards.Count - 1);
                }

            }


        }

        public void MoveTheif()
        {
            uIRestrictionPresenter.TurnOffAll();
            pointParentPresenter.ShowAll();
        }
        private void Update()
        {
            if (isPlace)
            {
                pointParentPresenter.EraseAll();
                uIRestrictionPresenter.Release();
                isPlace = false;
            }

        }
    }


}
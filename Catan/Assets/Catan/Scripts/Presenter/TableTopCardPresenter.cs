using Catan.Scripts.Card;
using Catan.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Presenter
{

    public class TableTopCardPresenter : MonoBehaviour
    {

        [SerializeField] GameObject TableTop;
        [SerializeField] GameObject Hand;
        public ToPleyerObject toPleyerObject;
        public ToCardObject toCardObject;
        public void CreateCard(PlayerId playerId)
        {
            // 生成
            var p = toPleyerObject.ToPlayer(playerId);
            foreach (GameObject g in p.GetComponent<Belongings>().cards)
            {

                GameObject tmpObject = GameObject.Instantiate(g, this.transform.position, Quaternion.identity);
                tmpObject.transform.parent = Hand.transform;
            }
        }

        public void DeleateCard(PlayerId playerId)
        {
            // 取得
            foreach (Transform n in TableTop.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
            foreach (Transform n in Hand.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
        }
    }

}
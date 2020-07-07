using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Player;
using Catan.Scripts.Card;

namespace Catan.Scripts.Presenter
{

    public class SpecialCardPresenter : MonoBehaviour
    {
        public ToPleyerObject toPleyerObject;
        public ToCardObject toCardObject;
        [SerializeField] GameObject specialHnad;
        public void CreateCard(PlayerId playerId)
        {
            // 生成
            var p = toPleyerObject.ToPlayer(playerId);
            foreach (GameObject g in p.GetComponent<Belongings>().scards)
            {

                GameObject tmpObject = GameObject.Instantiate(g, this.transform.position, Quaternion.identity);
                Debug.Log("oha");
                tmpObject.transform.SetParent(specialHnad.transform, false); // SetParentの第二引数で相対的な大きさにするかを決められる。
              //  ここでfalseを指定することで、プレハブ本来の大きさで子オブジェクトにすることができる。
            }
        }

        public void DeleateCard(PlayerId playerId)
        {
            // 取得
            foreach (Transform n in specialHnad.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
        }
    }

}
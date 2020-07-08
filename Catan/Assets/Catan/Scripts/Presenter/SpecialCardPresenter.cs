using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Player;
using Catan.Scripts.Card;
using UnityEngine.UI;
using Catan.Scripts.Manager;

namespace Catan.Scripts.Presenter
{

    public class SpecialCardPresenter : MonoBehaviour
    {
        public ToPleyerObject toPleyerObject;
        public ToCardObject toCardObject;
        public SpecialCardManeger specialCardManeger;
        [SerializeField] GameObject specialHnad;
        public void CreateCard(PlayerId playerId)
        {
            // 生成
            var p = toPleyerObject.ToPlayer(playerId);
            foreach (GameObject g in p.GetComponent<Belongings>().scards)
            {

                GameObject go = GameObject.Instantiate(g, new Vector3(0,0,0), Quaternion.identity);
                var cardType = g.GetComponent<SpecialCardEntity>().specialCardType;
                switch (cardType)
                {
                    case SpecialCardType.Harvest:
                        go.GetComponent<Button>().onClick.AddListener(() => specialCardManeger.Harvest());
                        Debug.Log("ha");
                        break;
                    case SpecialCardType.Knight:
                        go.GetComponent<Button>().onClick.AddListener(() => specialCardManeger.Knight());
                        Debug.Log("kn");
                        break;
                    case SpecialCardType.Monopolization:
                        go.GetComponent<Button>().onClick.AddListener(() => specialCardManeger.Monopolization());
                        Debug.Log("mon");
                        break;
                    case SpecialCardType.Road:
                        go.GetComponent<Button>().onClick.AddListener(() => specialCardManeger.MainRoad());
                        Debug.Log("ma");
                        break;
                    default:
                        Debug.Log("ooooooooooo");
                        break;
                }
                Debug.Log("oha");
                go.transform.SetParent(specialHnad.transform, false); // SetParentの第二引数で相対的な大きさにするかを決められる。
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
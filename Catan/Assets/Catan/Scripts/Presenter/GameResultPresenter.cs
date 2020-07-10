using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Catan.Scripts.Manager;
using System.Linq;
using DG.Tweening;
namespace Catan.Scripts.Presenter
{

    public class GameResultPresenter : MonoBehaviour
    {
        [SerializeField] GameObject resultBoard;
        [SerializeField] List<Text> pointText = new List<Text>(4);
        [SerializeField] List<Text> playerText = new List<Text>(4);

        public void ShowGameResult(IOrderedEnumerable<playerI> list)
        {
            int index = 0;
            foreach (playerI rec in list)
            {
                pointText[index].text = rec.point.ToString();
                playerText[index].text = rec.p.ToString();
                index++;
            }
            resultBoard.transform.DOMove(new Vector3(0, -300f, 0), 5.0f);

        }
    }

}
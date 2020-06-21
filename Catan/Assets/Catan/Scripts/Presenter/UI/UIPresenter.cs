using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Presenter
{

  public class UIPresenter : MonoBehaviour
  {
    private bool isOwnPlayer = false;
    private bool isOtherPlayer = false;
    private bool action = false;
    private bool build = false;
    private bool card = false;
    private bool trade = false;
    private bool negotiation = false;

    public GameObject turnPlayer;
    public GameObject ownPlayerPanel;
    public GameObject otherPlayerPanel;
    public GameObject actionPanel;

    public GameObject buildPanel;
    public GameObject cardPanel;
    public GameObject tradePanel;
    public GameObject negotiationPanel;
    public void OwnPlayer()
    {
      if (!isOwnPlayer)
      {
        isOwnPlayer = true;
        ownPlayerPanel.SetActive(true);

        if (!isOtherPlayer && !action)
        {
          turnPlayer.transform.Translate(-400, 0, 0);
        }

        else
        {
          isOtherPlayer = false;
          action = false;
          otherPlayerPanel.SetActive(false);
          actionPanel.SetActive(false);
        }
      }
      else
      {
        isOwnPlayer = false;
        turnPlayer.transform.Translate(400, 0, 0);
        ownPlayerPanel.SetActive(false);
      }
    }

    public void OtherPlayer()
    {
      if (!isOtherPlayer)
      {
        isOtherPlayer = true;
        otherPlayerPanel.SetActive(true);

        if (!isOwnPlayer && !action)
        {
          turnPlayer.transform.Translate(-400, 0, 0);
        }

        else
        {
          isOwnPlayer = false;
          action = false;
          actionPanel.SetActive(false);
          ownPlayerPanel.SetActive(false);
        }
      }
      else
      {
        isOtherPlayer = false;
        turnPlayer.transform.Translate(400, 0, 0);
        otherPlayerPanel.SetActive(false);
      }
    }

    public void Action()
    {
      if (!action)
      {
        action = true;
        actionPanel.SetActive(true);

        if (!isOtherPlayer && !isOwnPlayer)
        {
          turnPlayer.transform.Translate(-400, 0, 0);
        }

        else
        {
          isOtherPlayer = false;
          isOwnPlayer = false;
          ownPlayerPanel.SetActive(false);
          otherPlayerPanel.SetActive(false);
        }
      }
      else
      {
        action = false;
        turnPlayer.transform.Translate(400, 0, 0);
        actionPanel.SetActive(false);
      }
    }

    public void Build()
    {
      if (cardPanel.activeSelf == false && tradePanel.activeSelf == false && negotiationPanel.activeSelf == false)
      {
        buildPanel.SetActive(true);
      }
    }

    public void BuildCancel()
    {
      buildPanel.SetActive(false);
    }

    public void Card()
    {
      if (buildPanel.activeSelf == false && tradePanel.activeSelf == false && negotiationPanel.activeSelf == false)
      {
        cardPanel.SetActive(true);
      }
    }

    public void CardCancel()
    {
      cardPanel.SetActive(false);
    }

    public void Trade()
    {
      if (buildPanel.activeSelf == false && cardPanel.activeSelf == false && negotiationPanel.activeSelf == false)
      {
        tradePanel.SetActive(true);
      }
    }

    public void TradeCancel()
    {
      tradePanel.SetActive(false);
    }

    public void Negotiation()
    {
      if (buildPanel.activeSelf == false && cardPanel.activeSelf == false && tradePanel.activeSelf == false)
      {
        negotiationPanel.SetActive(true);
      }
    }


    public void NegotiationCancel()
    {
      negotiationPanel.SetActive(false);
    }
  }


}
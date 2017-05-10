using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class DealCards : Command
{

    private Player player;

    private int cardsAmount = 0;

    private List<Card> bagCard = new List<Card>();

    public override void Execute()
    {
        if (player != null)
        {
            FillBag();
            List<Card> _cards = new List<Card>();
            for (int i = 0; i < cardsAmount; i++)
            {
                Random rnd = new Random();
                int index = Random.Range(0,bagCard.Count);
                _cards.Add(bagCard[index]);
                bagCard.Remove(bagCard[index]);
            }
            player.SetCardsList(_cards);
        }
    }

    public DealCards(Player player,int cardsAmount)
    {
        this.player = player;
		this.cardsAmount = cardsAmount;
    }

    private void FillBag()
    {
        bagCard.Clear();
        for (int i = 0; i < 3; i++)
        {
            bagCard.Add(new Card(Card.CardTypes.Piedra));
            bagCard.Add(new Card(Card.CardTypes.Papel));
            bagCard.Add(new Card(Card.CardTypes.Tijera));
        }
    }
}
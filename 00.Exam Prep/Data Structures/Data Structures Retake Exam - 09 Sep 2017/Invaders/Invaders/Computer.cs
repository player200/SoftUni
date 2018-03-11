using System;
using System.Collections.Generic;
using System.Linq;

public class Computer : IComputer
{
    private LinkedList<Invader> byInvaders;
    private Dictionary<int, List<LinkedListNode<Invader>>> invaders;
    private int skips = 0;
    private int energy;

    public Computer(int energy)
    {
        if (energy < 0)
        {
            throw new ArgumentException();
        }

        this.byInvaders = new LinkedList<Invader>();
        this.invaders = new Dictionary<int, List<LinkedListNode<Invader>>>();
        this.energy = energy;
    }

    public int Energy
    {
        get
        {
            return this.energy;
        }
        private set
        {
            if (value < 0)
            {
                this.energy = 0;
            }
            else
            {
                this.energy = value;
            }
        }
    }

    public void Skip(int turns)
    {
        this.skips += turns;
        this.invaders = this.invaders.Where(x =>
        {
            int remDistance = x.Key - this.skips;
            if (remDistance <= 0)
            {
                this.Energy -= x.Value.Sum(y => y.Value.Damage);
                x.Value.ForEach(y => this.byInvaders.Remove(y));
            }
            return remDistance > 0;
        })
        .ToDictionary(x => x.Key, y => y.Value);
    }

    public void AddInvader(Invader invader)
    {
        LinkedListNode<Invader> linkedInvader = new LinkedListNode<Invader>(invader);

        int distance = invader.Distance;
        if (!this.invaders.ContainsKey(distance))
        {
            this.invaders[distance] = new List<LinkedListNode<Invader>>();
        }
        this.byInvaders.AddLast(linkedInvader);
        this.invaders[distance].Add(linkedInvader);
    }

    public void DestroyHighestPriorityTargets(int count)
    {
        foreach (var linkedListNode in this.invaders.SelectMany(x => x.Value)
            .OrderBy(x => x.Value)
            .Take(count))
        {
            this.byInvaders.Remove(linkedListNode);
        }
        var newDict = this.invaders.SelectMany(x => x.Value)
            .OrderBy(x => x.Value)
            .Skip(count);

        this.invaders = new Dictionary<int, List<LinkedListNode<Invader>>>();
        foreach (var item in newDict)
        {
            if (!this.invaders.ContainsKey(item.Value.Distance))
            {
                this.invaders.Add(item.Value.Distance, new List<LinkedListNode<Invader>>());
            }
            this.invaders[item.Value.Distance].Add(item);
        }
    }

    public void DestroyTargetsInRadius(int radius)
    {
        this.invaders = this.invaders
             .Where(x =>
             {
                 bool result = x.Key - this.skips > radius;

                 if (!result)
                 {
                     x.Value.ForEach(y => this.byInvaders.Remove(y));
                 }
                 return result;
             })
             .ToDictionary(x => x.Key, y => y.Value);
    }

    public IEnumerable<Invader> Invaders()
    {
        return this.byInvaders;
    }
}
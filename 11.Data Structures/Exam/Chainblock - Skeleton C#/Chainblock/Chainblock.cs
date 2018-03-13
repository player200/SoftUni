using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Chainblock : IChainblock
{
    private Dictionary<int, Transaction> chainer;

    public Chainblock()
    {
        this.chainer = new Dictionary<int, Transaction>();
    }

    public int Count => this.chainer.Count;

    public void Add(Transaction tx)
    {
        if (!this.chainer.ContainsKey(tx.Id))
        {
            this.chainer[tx.Id] = tx;
        }
    }

    public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
    {
        if (!this.chainer.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        var result = this.chainer[id];
        result.Status = newStatus;
    }

    public bool Contains(Transaction tx)
    {
        return this.chainer.ContainsKey(tx.Id);
    }

    public bool Contains(int id)
    {
        return this.chainer.ContainsKey(id);
    }

    public IEnumerable<Transaction> GetAllInAmountRange(double lo, double hi)
    {
        var result = this.chainer
            .Values
            .Where(x => x.Amount >= lo && x.Amount <= hi);

        return result;
    }

    public IEnumerable<Transaction> GetAllOrderedByAmountDescendingThenById()
    {
        return this.chainer
            .Values
            .OrderByDescending(x => x.Amount)
            .ThenBy(x=>x.Id);
    }

    public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
    {
        var result = this.chainer
            .Values
            .Where(x=>x.Status==status)
            .OrderByDescending(x => x.Amount)
            .Select(x=>x.To);
        if (!result.Any())
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
    {
        var result = this.chainer
            .Values
            .Where(x => x.Status == status)
            .OrderByDescending(x => x.Amount)
            .Select(x => x.From);
        if (!result.Any())
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public Transaction GetById(int id)
    {
        if (!this.chainer.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        return this.chainer[id];
    }

    public IEnumerable<Transaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        var result = this.chainer
            .Values
            .Where(x => x.To == receiver
            && x.Amount >= lo
            && x.Amount < hi)
            .OrderByDescending(x=>x.Amount)
            .ThenBy(x=>x.Id);
        if (!result.Any())
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<Transaction> GetByReceiverOrderedByAmountThenById(string receiver)
    {
        var result = this.chainer
            .Values
            .Where(x => x.To == receiver)
            .ToList();
        if (this.chainer.Count == 0)
        {
            throw new InvalidOperationException();
        }
        if (result.Count()==0)
        {
            throw new InvalidOperationException();
        }

        return result.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
    }

    public IEnumerable<Transaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        var result = this.chainer
            .Values
            .Where(x => x.From == sender
            && x.Amount > amount)
            .OrderByDescending(x => x.Amount);
        if (!result.Any())
        {
            throw new InvalidOperationException();
        }
        return result;
    }

    public IEnumerable<Transaction> GetBySenderOrderedByAmountDescending(string sender)
    {
        var result = this.chainer.Values.Where(x => x.From == sender);
        if (!result.Any())
        {
            throw new InvalidOperationException();
        }

        return result.OrderByDescending(x=>x.Amount);
    }

    public IEnumerable<Transaction> GetByTransactionStatus(TransactionStatus status)
    {
        var result = this.chainer.Values.Where(x => x.Status == status);
        if (!result.Any())
        {
            throw new InvalidOperationException();
        }

        return result.OrderByDescending(x => x.Amount);
    }

    public IEnumerable<Transaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {
        return this.chainer
            .Values
            .Where(x => x.Status == status && x.Amount <= amount)
            .OrderByDescending(x=>x.Amount);
    }

    public IEnumerator<Transaction> GetEnumerator()
    {
        foreach (var trans in this.chainer.Values)
        {
            yield return trans;
        }
    }

    public void RemoveTransactionById(int id)
    {
        if (!this.chainer.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        this.chainer.Remove(id);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}


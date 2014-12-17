using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class DebateRepository : IDebateRepository
    {
        RateMyDebateContext db = new RateMyDebateContext();

        public void Dispose()
        {
            db.Dispose();
        }

        public IQueryable<Debate> GetDebates
        {
            get { return db.Debate; }
        }
        public Debate FindDebate(int? debateId)
        {
            Debate debate = db.Debate.Find(debateId);
            return debate;
        }

        public void AddDebate(Debate debate)
        {
            db.Debate.Add(debate);
        }

        public void UpdateDebate(Debate debate)
        {
            db.Entry(debate).State = EntityState.Modified;
        }

        public void DeleteDebate(int debateId)
        {
            var debate = db.Debate.Find(debateId);
            db.Debate.Remove(debate);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
    public interface IDebateRepository : IDisposable
    {
        IQueryable<Debate> GetDebates { get; }
        Debate FindDebate(int? debateId);
        void AddDebate(Debate debate);
        void UpdateDebate(Debate debate);
        void DeleteDebate(int debateId);
        void Save();
    }
}
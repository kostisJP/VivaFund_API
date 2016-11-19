using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;
using VivaFund.Interfaces;

namespace VivaFund.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _context;
        public MemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public MemberRepository()
        {
            _context = new ApplicationDbContext();
        }

        public Member GetMemberById(int id)
        {
            var member = _context.Members.Single(u => u.MemberId == id);
            return member;
        }
        public IEnumerable<Member> GetAllMembers()
        {
            var member = _context.Members.ToList();
            return member;
        }

        public Member GetMemberByToken(Guid token)
        {
            var member = _context.Members.FirstOrDefault(u => u.Token == token);
            return member;
        }

        public void InsertOrUpdateMember(Member member)
        {
            try
            {
                member.UpdatedDate = DateTime.Now;
                if (_context.Members.Find(member.MemberId) == null)
                {
                    _context.Members.Add(member);

                    //_context.Entry(member).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(member).State = EntityState.Modified;
                }
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry

                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                            subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        Console.WriteLine(message);
                    }
                }
            }
        }


    }
}

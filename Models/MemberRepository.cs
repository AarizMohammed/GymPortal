namespace GymPortal.Models
{
    public class MemberRepository : IMemberRepository
    {
        private static readonly List<MemberSignupViewModel> _members = new();

        public int AddMember(MemberSignupViewModel m)
        {
            _members.Add(m);
            return _members.Count;
        }

        public IEnumerable<MemberSignupViewModel> GetAllMembers()
        {
            return _members.OrderBy(m => m.Name);
        }

        public MemberSignupViewModel FindByEmail(string email)
        {
            return _members.FirstOrDefault(m =>
                m.Email.Equals(email, System.StringComparison.OrdinalIgnoreCase));
        }

        public MemberSignupViewModel FindByPhone(string phone)
        {
            return _members.FirstOrDefault(m => m.Phone == phone);
        }
    }
}


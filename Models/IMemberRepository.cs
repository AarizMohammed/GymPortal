using System;

namespace GymPortal.Models;

public interface IMemberRepository
{
    int AddMember(MemberSignupViewModel m);
        IEnumerable<MemberSignupViewModel> GetAllMembers();
        MemberSignupViewModel FindByEmail(string email);
        MemberSignupViewModel FindByPhone(string phone);
}

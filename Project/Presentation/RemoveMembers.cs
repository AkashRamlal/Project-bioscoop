public static class RemoveMember
{
    public static void Start()
    {
        var members = new AccountsAccess().GetAllMembers();
        Console.WriteLine("Select a member to delete:");
        for (int i = 0; i < members.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {members[i].Naam} {members[i].Achternaam}");
        }
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= members.Count)
        {
            var selectedMember = members[choice - 1];
            new AccountsAccess().Delete(selectedMember);
            Console.WriteLine($"Member {selectedMember.Naam} {selectedMember.Achternaam} has been deleted.");
        }
        else
        {
            Console.WriteLine("Invalid selection. No member deleted.");
        }
        
    }
       
}
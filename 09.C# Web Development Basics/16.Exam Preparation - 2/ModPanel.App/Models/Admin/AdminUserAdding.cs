namespace ModPanel.App.Models.Admin
{
    using ModPanel.App.Data.Models;

    public class AdminUserAdding
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public PositionType Position { get; set; }

        public int Posts { get; set; }

        public bool IsApproved { get; set; }
    }
}
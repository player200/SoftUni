namespace _02.SotialNetwork.Model
{
    public class FriendShip
    {
        public int FromUserId { get; set; }

        public Users FromUser { get; set; }

        public int ToUserId { get; set; }

        public Users ToUser { get; set; }
    }
}
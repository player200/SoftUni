namespace _02.SotialNetwork.Model
{
    public class AlbumPicture
    {
        public int PictureId { get; set; }

        public Picture Picture { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
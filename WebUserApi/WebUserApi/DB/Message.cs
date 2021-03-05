using System;
using System.Collections.Generic;

#nullable disable

namespace WebuUserApi.DB
{
    public partial class Message
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public string Mesage { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}

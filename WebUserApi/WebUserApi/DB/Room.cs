using System;
using System.Collections.Generic;

#nullable disable

namespace WebuUserApi.DB
{
    public partial class Room
    {
        public Room()
        {
            Messages = new HashSet<Message>();
            Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Type { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}

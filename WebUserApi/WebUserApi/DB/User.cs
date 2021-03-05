using System;
using System.Collections.Generic;

#nullable disable

namespace WebuUserApi.DB
{
    public partial class User
    {
        public User()
        {
            Messages = new HashSet<Message>();
            Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}

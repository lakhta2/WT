using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WatchTogetherDataAccess.Entities
{
    [Table("CurrentlyBroadcast")]
    public class CurrentlyBroadcastEntity
    {
        public Guid BroadcasterId { get; set; }
        //public List<UserEntity>? Users { get; set; }
    }
}

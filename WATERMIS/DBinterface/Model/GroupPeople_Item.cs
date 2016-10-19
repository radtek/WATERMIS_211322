using System;
using System.Collections.Generic;
using System.Text;

namespace DBinterface.Model
{
   public class GroupPeople_Item
    {
       public List<GroupPeople_Model> GroupPeople_Items { get; set; }
       public Guid GroupID { get; set; }
    }
}

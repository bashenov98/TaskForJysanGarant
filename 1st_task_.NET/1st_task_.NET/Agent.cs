using System;
namespace st_task_.NET
{
    public class Agent
    {
        public int id;
        public string iinOrBin;
        public DateTime created_at;
        public string created_by;
        public DateTime changed_at;
        public string changed_by;

        public Agent(int _id, string _iinOrBin, DateTime _created_at, string _created_by, DateTime _changed_at, string _changed_by)
        {
            id = _id;
            iinOrBin = _iinOrBin;
            created_at = _created_at;
            created_by = _created_by;
            changed_at = _changed_at;
            changed_by = _changed_by;
        }
        public Agent() { }
    }


}
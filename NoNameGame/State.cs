using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace NoNameGame
{
    class State
    {
        struct Result
        {
            public String Name { get; set; }
            public String Record { get; set; }
        }

        public State() { }
        public State(String new_name, String new_time)
        {

            Result res = new Result() { Name = new_name, Record = new_time };
            StreamWriter w = new StreamWriter("records.json", true);
            String ser = JsonSerializer.Serialize<Result>(res);
            w.WriteLine(ser);
            w.Close();
        }

        public List<String> GetRecords()
        {
            Result res;
            String s;
            StreamReader r = new StreamReader("records.json");
            while ((s = r.ReadLine()) != null)
            {
                //res = JsonSerializer.Deserialize<Result>(s);
            }
            List<String> rec = new List<String>();

            return rec;
        }

    }
}

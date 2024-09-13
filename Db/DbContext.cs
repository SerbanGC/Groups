using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.HttpResults;
using Model;

namespace Service
{
    public class DbContext
    {
        public Dictionary<string, List<Group>> groups = new Dictionary<string, List<Group>>{
                {"1", new List<Group>{new(1, 101, "A", "B", "C"), new(1, 102, "D", "E", "F")}},
                {"2", new List<Group>{new(2, 101, "X", "Y", "Z"), new(2, 203, "M", "N", "O")}}
        };

    }
}
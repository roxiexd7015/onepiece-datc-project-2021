using AmbrosiaAlert.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AmbrosiaAlert.Shared.ViewModels
{
    public class VoteTypeViewModel
    {
        public VoteTypeViewModel(VoteType model)
        {
            Id = model.Id;
            Name = model.Name;
            Value = model.Value;
        }

        [JsonConstructor]
        public VoteTypeViewModel(int id, string name, int value)
        {
            Id = id;
            Name = name;
            Value = value;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}

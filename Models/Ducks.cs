using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AnimeListandUserList.Models
{
    public class Ducks
    {
        public string Answer { get; set; }
        public bool Forced { get; set; }
        public string Image { get; set; }
    }
}
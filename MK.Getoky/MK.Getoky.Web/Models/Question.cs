using System;
namespace MK.Getoky.Web.Models
{
    public class Question
    {
        public Question() { }

        public Question(string text)
        {
            Text = text;
        }

        public string Text { get; set; } = string.Empty;

    }
}


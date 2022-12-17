using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor.Sources.Notes
{
    public class Note : IComparable<Note>
    {
        public string? Title { get; set; }
        public string? Body { get; set; }
        public string? Priority { get; set; }
        public DateTime Date { get; set; }

        public Note(string? title = null, string? body = null, string? priority = null)
        {
            Title = title;
            Body = body;
            Priority = priority;
            Date = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{Title}\n{Priority}\n{Body}\n{Date}";
        }
        public int CompareTo(Note? other)
        {
            if (other is null) throw new ArgumentException("Некорректное значение параметра");
            return Date.CompareTo(other.Date);
        }
    }
}

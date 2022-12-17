using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Encryptor.Sources.Notes
{
    public class NoteList : List<Note>
    {
        public List<Note> FindPriority(string priority) => FindAll(x => x.Priority.Equals(priority));
        public List<Note> FindDuplicates(string title) => FindAll(x => x.Title.Equals(title));
        public int FindIndexByTitle(string title) => FindIndex(x => x.Title.Equals(title));
        public bool RemoveByTitle(string title)
        {
            Note temp = Find(x => x.Title.Equals(title));
            if (temp != null)
            {
                Remove(temp);
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            string temp = "";
            foreach (Note item in this)
            {
                temp += item + "\n";
            }
            return temp;
        }
    }
}

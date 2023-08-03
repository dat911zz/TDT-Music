using System.Collections.Generic;

namespace TDT.Core.DTO
{
    public class LyricDTO
    {
        private List<Sentence> _sentences;
        public List<Sentence> sentences { get => _sentences; set => _sentences = value; }
    }

    public class Sentence
    {
        public List<Word> words { get; set; }
    }

    public class Word
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string data { get; set; }
    }
}

using System.Collections.Generic;

namespace TDT.Core.DTO
{
    public class LyricDTO
    {
        private string _encodeId;
        private List<Sentence> _sentences;
        public List<Sentence> sentences { get => _sentences; set => _sentences = value; }
        public string encodeId { get => _encodeId; set => _encodeId = value; }
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

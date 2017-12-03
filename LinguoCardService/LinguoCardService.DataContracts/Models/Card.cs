namespace LinguoCardService.DataContracts.Models
{
    public class Card 
    {
        public int Id;
        public string EnglishValue;
        public string RussianValue;

        public Card(WordDictionary dictionary)
        {
            Id = dictionary.Id;
            EnglishValue = dictionary.EnglishValue;
            RussianValue = dictionary.RussianValue;
        }

        public  string AdditinalWord { get; set; }
    }
}

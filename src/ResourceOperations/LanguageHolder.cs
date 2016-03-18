namespace ResxTranslator.ResourceOperations
{
    public class LanguageHolder
    {
        public string Id { get; set; }
        public string Filename { get; set; }

        public override string ToString()
        {
            return Id;
        }
    }
}
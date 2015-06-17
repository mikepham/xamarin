namespace Demo.ViewModels
{
    using System.IO;
    using System.Reflection;

    public class LoremIpsumViewModel : ViewModel
    {
        private const string LoremIpsumResourceKey = "Demo.Resources.loremipsum.txt";

        public LoremIpsumViewModel()
        {
            var stream = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(LoremIpsumResourceKey);

            using (var reader = new StreamReader(stream))
            {
                this.LoremIpsumText = reader.ReadToEnd();
            }
        }

        public string LoremIpsumText { get; set; }
    }
}
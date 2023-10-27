using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIST33150ConsoleAppEmpty.Domain;

namespace BAIST33150ConsoleAppEmpty.Pages
{
    public class DynamicDisplaySampleModelModel : PageModel
    {
        private List<SampleClass> _sampleObjectCollection = new(); 
        public List<SampleClass> SampleObjectCollection 
        { 
            get {  return _sampleObjectCollection; } 
        }

        // or 
        // public List<SampleClass> SampleObjectCollection = new();
        public void OnGet()
        {
            SampleClass SampleObject;

            SampleObject = new()
            {
                FirstProperty = "1",
                SecondProperty = "One",
            };
            SampleObjectCollection.Add(SampleObject);

            SampleObject = new();
            SampleObject.FirstProperty = "2";
            SampleObject.SecondProperty = "Two";
            SampleObjectCollection.Add(SampleObject);

           SampleObject = new()
           {
                FirstProperty = "3",
                SecondProperty = "Three",
           };
            SampleObjectCollection.Add(SampleObject);
        }
    }
}

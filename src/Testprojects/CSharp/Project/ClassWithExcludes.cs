
namespace Test
{
    public class ClassWithExcludes
    {
        public string IncludedProperty { get; set; }

        [CoverageExclude]
        public string ExcludedProperty { get; set; }

        public void IncludedMethod()
        {
            this.IncludedProperty = "Test";
        }

        [CoverageExclude]
        public void ExcludedMethod()
        {
            this.ExcludedProperty = "Test";
        }
    }
}
Add UI - improving securityDocument dependencies - adding new feature
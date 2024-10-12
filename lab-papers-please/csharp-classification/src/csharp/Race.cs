namespace Csharp
{
    // Class used to initialize/describe the 'rules' of how each race of each universe
    class Race
    {   
        // The required properties of each Race
        public string Name {get;set;}
        public bool IsHumanoid {get; set;}
        public string? Planet {get; set;}
        public int Age {get; set;}
        public List<string>? Traits { get; set; }

        // Constructor for a more concise race definition
        public Race(string name, bool isHumanoid, string planet, int age, List<string> traits)
        {
            Name = name;
            IsHumanoid = isHumanoid;
            Planet = planet;
            Age = age;
            Traits = traits;
        }

    }
}
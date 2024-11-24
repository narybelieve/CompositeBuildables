using Nautilus.Options;

/// Inherit from the abstract ModOptions
public class CompositeBuildableOptions : ModOptions
{
    /// The base ModOptions class takes a string name as an argument
    public CompositeBuildableOptions() : base("My Mod Options")
    {
        /// A ModSliderOption is used to draw a numeric value as a slider in the options menu with a
        /// minimum and maximum value.
        /// 
        /// In this example we are setting a minimum value of 0 a maximum of 50,  a
        /// DefaultValue of 25 (which will be represented by a notch on the slider)
        /// and an initial value of 15.
        AddItem(ModSliderOption.Create("SliderId", "My Slider", 0, 50, 15, 25));
    }
}
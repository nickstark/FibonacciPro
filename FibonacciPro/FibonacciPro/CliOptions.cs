using CommandLine;
using CommandLine.Text;

namespace FibonacciPro
{
    internal class CliOptions
    {
        [Option('i', "input", Required = false, HelpText = "Input file to read.")]
        public string InputFile { get; set; }

        [Option('o', "output", Required = false, HelpText = "Output file to write.")]
        public string OutputFile { get; set; }

        [Option('t', "interactive", HelpText = "Function in interactive mode.")]
        public bool InteractiveMode { get; set; }

        [ValueOption(0)]
        public string InputNumber { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this);
        }
    }
}
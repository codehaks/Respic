#r "nuget:SixLabors.ImageSharp, 1.0.0-beta0005"

using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

var curDir = System.IO.Directory.GetCurrentDirectory();
var inDir = curDir + @"\in\";
var outDir = curDir + @"\out\";

var files = System.IO.Directory.GetFiles(inDir);

foreach (FileInfo file in files.Where(f => f.EndsWith(".png")).Select(f => new FileInfo(f)))
{
    using (SixLabors.ImageSharp.Image<Rgba32> image = SixLabors.ImageSharp.Image.Load(file.FullName))
    {
        image.Mutate(x => x
             .Resize(100, 100));
        image.Save(outDir + file.Name);
    }
    Console.WriteLine($"{file.Name} resized.");
}

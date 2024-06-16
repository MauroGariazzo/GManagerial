using PdfSharp.Fonts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Fonts
{
    internal class FontResolver : IFontResolver
    {
        public string DefaultFontName => "OpenSans";

        public byte[] GetFont(string faceName)
        {
            switch (faceName)
            {
                case "OpenSans": return LoadFontData("MyApp.Fonts.OpenSans-Regular.ttf");
                case "OpenSans#b": return LoadFontData("MyApp.Fonts.OpenSans-Bold.ttf");
                case "OpenSans#i": return LoadFontData("MyApp.Fonts.OpenSans-Italic.ttf");
                case "OpenSans#bi": return LoadFontData("MyApp.Fonts.OpenSans-BoldItalic.ttf");
                default: return null;
            }
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            string faceName = familyName.ToLowerInvariant();

            if (isBold) faceName += "#b";
            if (isItalic) faceName += "#i";

            return new FontResolverInfo(faceName);
        }

        private byte[] LoadFontData(string resourceName)
        {
            var assembly = typeof(FontResolver).Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new FileNotFoundException($"Resource not found: {resourceName}");

                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}

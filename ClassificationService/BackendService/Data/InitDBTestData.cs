using BackendService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackendService.Data
{
    public class InitDBTestData
    {

        public static void Initialize(BackendServiceContext context)
        {
            if (context.Ship.Any()) { return; }

            var ships = new Ship[]
            {
                new Ship{Name="Nostromus"},
                new Ship{Name="Itaca"},
                new Ship{Name="Flying Dutchman"}
            };
            
            foreach (var s in ships)
            {
                context.Ship.Add(s);
            }
            context.SaveChanges();

            var ropes = new Rope[]
            {
            new Rope{ Tag = Tag.unspecified , AddedOn=DateTime.Parse("2019-12-03"), Probability = -1, ShipID=1},
            new Rope{ Tag = Tag.goodRope , AddedOn=DateTime.Parse("2019-12-03"), Probability = 0.78, ShipID=1},
            new Rope{ Tag = Tag.unspecified , AddedOn=DateTime.Parse("2019-12-03"), Probability = 0.5, ShipID=1},
            new Rope{ Tag = Tag.badRope , AddedOn=DateTime.Parse("2019-12-03"), Probability = 0.72, ShipID=2},
            new Rope{ Tag = Tag.badRope , AddedOn=DateTime.Parse("2019-12-03"), Probability = 0.58, ShipID=2},
            new Rope{ Tag = Tag.goodRope , AddedOn=DateTime.Parse("2019-12-03"), Probability = 0.96, ShipID=3},
            };
            foreach (var r in ropes)
            {
                context.Rope.Add(r);
            }
            context.SaveChanges();

            var images = new Image[]
            {
                new Image{RawImage= GetRawImage(FindWWWResources("good1.jpg")), RopeID = 1},
                new Image{RawImage= GetRawImage(FindWWWResources("good2.jpg")), RopeID = 2},
                new Image{RawImage= GetRawImage(FindWWWResources("bad1.jpg")), RopeID = 4},
                new Image{RawImage= GetRawImage(FindWWWResources("bad2.jpg")), RopeID = 5},
                new Image{RawImage= GetRawImage(FindWWWResources("bad3.jpg")), RopeID = 6}
            };
            foreach (var i in images)
            {
                context.Image.Add(i);
            }
            context.SaveChanges();
        }

        public static string FindWWWResources(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new InvalidOperationException("The file has not been found.");

            }
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = "..\\..\\..\\wwwroot\\images\\";            
            string imageFile = Path.GetFullPath(baseDirectory + relativePath + filename);

            return imageFile;
        }

        static byte[] GetRawImage(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }
    }
}
